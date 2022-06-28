using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class DummyGridRenderer : IGridRender
    {
        private int rendererPositions = 0;
        public int RenderedPositions => rendererPositions;

        public void Render(IGridXZ<bool> grid)
        {
            foreach(var pos in grid.GridArray)
            {
                if(pos.Value)
                    rendererPositions++;
            }
                
        }
    }
}