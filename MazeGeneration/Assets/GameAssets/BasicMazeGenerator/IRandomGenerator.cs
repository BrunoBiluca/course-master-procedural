namespace GameAssets.BasicMazeGenerator
{
    public interface IRandomGenerator
    {
        int Range(int minInclusive, int maxExclusive);
    }
}