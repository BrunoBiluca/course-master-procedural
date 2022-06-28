using NUnit.Framework;
using System.Linq;
using UnityEngine;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class BasicMazeGeneratorTests
    {
        [Test]
        public void ShouldInitializeWithFilledMaze()
        {
            var gridXZ = new GridXZ<bool>(2, 2, 1);
            var maze = new BasicMazeGenerator(gridXZ);

            Assert.AreEqual(true, maze.GetValue(0, 0));
            Assert.AreEqual(true, maze.GetValue(0, 1));
            Assert.AreEqual(true, maze.GetValue(1, 0));
            Assert.AreEqual(true, maze.GetValue(1, 1));
        }

        [Test]
        public void ShouldCreateCenterCorridor()
        {
            var gridXZ = new GridXZ<bool>(3, 3, 1);
            var maze = new BasicMazeGenerator(gridXZ);

            maze.Generate(new StraightCrawler(1));

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
            var gridXZ = new GridXZ<bool>(2, 2, 1);
            var maze = new BasicMazeGenerator(gridXZ);

            maze.Generate(new StraightCrawler(1));

            var gridRenderer = new DummyGridRenderer();
            maze.Render(gridRenderer);

            Assert.AreEqual(2, gridRenderer.RenderedPositions);
        }

        [Test]
        public void ShouldCreateCubesForAllFilledPositions()
        {
            var gridXZ = new GridXZ<bool>(2, 2, 1);
            var maze = new BasicMazeGenerator(gridXZ);

            maze.Generate(new StraightCrawler(1));

            maze.Render(new CubeGridRenderer());

            var renderedObjects = Object.FindObjectsOfType<GameObject>()
                .Where(go => go.name == CubeGridRenderer.OBJECT_NAME);

            Assert.AreEqual(2, renderedObjects.Count());
        }
    }
}