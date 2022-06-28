using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public class BasicMazeGenerator
    {
        private readonly IGridXZ<bool> grid;

        public BasicMazeGenerator(IGridXZ<bool> grid)
        {
            this.grid = grid;
            grid.Fill(true);
        }

        public bool GetValue(int x, int z)
        {
            return grid.GetValue(x, z);
        }

        public void Generate(IGridCrawler crawler)
        {
            crawler.Craw(grid);
        }

        public void Render(IGridRender gridRenderer)
        {
            gridRenderer.Render(grid);
        }
    }
}