using NUnit.Framework;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class StraightCrawlerTests
    {
        [Test]
        public void ShouldCreateCenterCorridor()
        {
            var gridXZ = new GridXZ<bool>(2, 2, 1);

            var crawler = new StraightCrawler(1);
            crawler.Craw(gridXZ, true);

            Assert.AreEqual(false, gridXZ.GetValue(0, 0));
            Assert.AreEqual(false, gridXZ.GetValue(1, 0));

            Assert.AreEqual(true, gridXZ.GetValue(0, 1));
            Assert.AreEqual(true, gridXZ.GetValue(1, 1));
        }
    }
}