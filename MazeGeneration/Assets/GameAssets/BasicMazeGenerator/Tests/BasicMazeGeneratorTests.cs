using NUnit.Framework;
using System;
using System.Linq;
using UnityEngine;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class BasicMazeGeneratorTests
    {
        [Test]
        public void ShouldNotReturnMazeWhenGeneratorDidNotRun()
        {
            var generator = new BasicMazeGenerator(2, 2);

            Assert.IsFalse(generator.WasMazeGenerated);
            Assert.Throws<InvalidOperationException>(() => generator.GetMaze());
        }

        [Test]
        public void ShouldCreateCenterCorridor()
        {
            var maze = new BasicMazeGenerator(3, 3)
                .AddCrawler(new StraightCrawler(1))
                .Generate();

            Assert.AreEqual(true, maze.GetValue(0, 0));
            Assert.AreEqual(false, maze.GetValue(0, 1));
            Assert.AreEqual(true, maze.GetValue(0, 2));

            Assert.AreEqual(true, maze.GetValue(1, 0));
            Assert.AreEqual(false, maze.GetValue(1, 1));
            Assert.AreEqual(true, maze.GetValue(1, 2));

            Assert.AreEqual(true, maze.GetValue(2, 0));
            Assert.AreEqual(false, maze.GetValue(2, 1));
            Assert.AreEqual(true, maze.GetValue(2, 2));
        }

        [Test]
        public void ShouldRenderAllFilledPositions()
        {
            var maze = new BasicMazeGenerator(3, 3)
                .AddCrawler(new StraightCrawler(1))
                .Generate();

            var gridRenderer = new DummyGridRenderer();
            gridRenderer.Render(maze);

            Assert.AreEqual(6, gridRenderer.RenderedPositions);
        }

        [Test]
        public void ShouldCreateCubesForAllFilledPositions()
        {
            var gridXZ = new GridXZ<bool>(3, 3, 1);
            var maze = new BasicMazeGenerator(3, 3)
                .AddCrawler(new StraightCrawler(1))
                .Generate();

            new CubeGridRenderer().Render(maze);

            var renderedObjects = UnityEngine.Object.FindObjectsOfType<GameObject>()
                .Where(go => go.name == CubeGridRenderer.OBJECT_NAME);

            Assert.AreEqual(6, renderedObjects.Count());
        }
    }
}