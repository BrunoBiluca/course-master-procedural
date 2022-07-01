using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public interface IGridRender
    {
        void Render(IGridXZ<bool> position);
    }
}