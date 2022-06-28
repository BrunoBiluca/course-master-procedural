using UnityEngine;

namespace GameAssets.BasicMazeGenerator
{
    public class UnityRandomGenerator : IRandomGenerator
    {
        public int Range(int minInclusive, int maxExclusive)
        {
            return Random.Range(minInclusive, maxExclusive);
        }
    }
}