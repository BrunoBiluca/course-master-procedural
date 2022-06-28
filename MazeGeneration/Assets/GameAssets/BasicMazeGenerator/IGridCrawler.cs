using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public interface IGridCrawler
    {
        void Craw(IGridXZ<bool> grid, bool value = false);
    }
}