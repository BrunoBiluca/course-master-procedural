using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public interface IGridCrawler
    {
        void Craw(Maze maze, bool value = false);
    }
}