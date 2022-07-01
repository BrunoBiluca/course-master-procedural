using NUnit.Framework;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class StraightCrawlerTests
    {
        [Test]
        public void ShouldCreateCenterCorridor()
        {
            var maze = new Maze(2, 2, 1);

            var crawler = new StraightCrawler(1);
            crawler.Craw(maze, true);

            Assert.AreEqual(false, maze.GetValue(0, 0));
            Assert.AreEqual(false, maze.GetValue(1, 0));

            Assert.AreEqual(true, maze.GetValue(0, 1));
            Assert.AreEqual(true, maze.GetValue(1, 1));
        }
    }
}