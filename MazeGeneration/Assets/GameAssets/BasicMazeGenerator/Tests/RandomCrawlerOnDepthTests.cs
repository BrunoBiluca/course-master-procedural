using NUnit.Framework;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class RandomCrawlerOnDepthTests
    {
        [Test]
        public void ShouldCreatePathOnDepthInGrid()
        {
            var maze = new Maze(2, 2, 1);

            var randomGenerator = new RandomCrawlerDummyValueBuilder()
                .StartX(0)
                .CrawFowardZ()
                .CrawFowardZ()
                .Build();

            var crawler = new RandomCrawlerOnDepth(randomGenerator);

            crawler.SetBorderPadding(0).Craw(maze, true);

            Assert.IsFalse(maze.GetValue(1, 0));
            Assert.IsFalse(maze.GetValue(1, 1));

            Assert.IsTrue(maze.GetValue(0, 0));
            Assert.IsTrue(maze.GetValue(0, 1));
        }

        [Test]
        public void ShouldCrawOverAllWhenAxisAreChangingGrid()
        {
            var grid = new Maze(2, 2, 1);

            var randomGenerator = new RandomCrawlerDummyValueBuilder()
                .StartX(0)
                .CrawFowardX()
                .CrawFowardZ()
                .CrawBackwardsX()
                .CrawFowardZ()
                .Build();

            var crawler = new RandomCrawlerOnDepth(randomGenerator);

            crawler.SetBorderPadding(0).Craw(grid, true);

            Assert.IsTrue(grid.GetValue(0, 0));
            Assert.IsTrue(grid.GetValue(1, 0));
            Assert.IsTrue(grid.GetValue(1, 1));
            Assert.IsTrue(grid.GetValue(0, 1));
        }
    }
}