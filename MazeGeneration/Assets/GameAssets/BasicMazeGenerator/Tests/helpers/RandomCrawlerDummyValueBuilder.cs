using System.Collections.Generic;
using UnityFoundation.Code;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class RandomCrawlerDummyValueBuilder
    {
        private readonly List<int> dummyValues;

        public RandomCrawlerDummyValueBuilder()
        {
            dummyValues = new List<int>();
        }

        public RandomCrawlerDummyValueBuilder StartX(int value)
        {
            dummyValues.Add(value);
            return this;
        }

        public RandomCrawlerDummyValueBuilder StartZ(int value)
        {
            dummyValues.Add(value);
            return this;
        }

        public RandomCrawlerDummyValueBuilder CrawFowardX()
        {
            dummyValues.AddRange(new int[] { 0, 1 });
            return this;
        }

        public RandomCrawlerDummyValueBuilder CrawBackwardsX()
        {
            dummyValues.AddRange(new int[] { 0, -1 });
            return this;
        }

        public RandomCrawlerDummyValueBuilder CrawFowardZ()
        {
            dummyValues.AddRange(new int[] { 99, 1 });
            return this;
        }

        public IRandomGenerator Build()
        {
            return new DummyRandomGenerator(dummyValues.ToArray());
        }
    }
}