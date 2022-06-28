using NUnit.Framework;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class RandomCrawlerTests
    {
        [Test]
        public void ShouldCreatePathVerticallyInGrid()
        {
            var grid = new GridXZ<bool>(2, 2, 1);

            var randomGenerator = new RandomCrawlerDummyValueBuilder()
                .StartX(0)
                .CrawFowardZ()
                .CrawFowardZ()
                .Build();

            var crawler = new RandomCrawler(randomGenerator);

            crawler.SetBorderPadding(0).Craw(grid, true);

            Assert.IsFalse(grid.GetValue(1, 0));
            Assert.IsFalse(grid.GetValue(1, 1));

            Assert.IsTrue(grid.GetValue(0, 0));
            Assert.IsTrue(grid.GetValue(0, 1));
        }

        [Test]
        public void ShouldCrawOverAllWhenAxisAreChangingGrid()
        {
            var grid = new GridXZ<bool>(2, 2, 1);

            var randomGenerator = new RandomCrawlerDummyValueBuilder()
                .StartX(0)
                .CrawFowardX()
                .CrawFowardZ()
                .CrawBackwardsX()
                .CrawFowardZ()
                .Build();

            var crawler = new RandomCrawler(randomGenerator);

            crawler.SetBorderPadding(0).Craw(grid, true);

            Assert.IsTrue(grid.GetValue(0, 0));
            Assert.IsTrue(grid.GetValue(1, 0));
            Assert.IsTrue(grid.GetValue(1, 1));
            Assert.IsTrue(grid.GetValue(0, 1));
        }
    }
}