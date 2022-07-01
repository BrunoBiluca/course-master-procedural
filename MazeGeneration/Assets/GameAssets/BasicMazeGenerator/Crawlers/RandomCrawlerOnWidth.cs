using UnityFoundation.Code;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public class RandomCrawlerOnWidth : IGridCrawler
    {
        private readonly IRandomGenerator random;
        private int padding;

        public RandomCrawlerOnWidth(IRandomGenerator random)
        {
            this.random = random;
        }

        public RandomCrawlerOnWidth SetBorderPadding(int value)
        {
            padding = value;
            return this;
        }

        public void Craw(Maze maze, bool value = false)
        {
            var x = random.Range(padding, maze.Width - 1);
            var z = padding;

            while(!IsGridBorder(maze, x, z))
            {
                maze.TrySetValue(x, z, value);
                if(random.Range(0, 100) < 50)
                    x += random.Range(-1, 2);
                else
                    z += random.Range(0, 2);
            }
        }

        private bool IsGridBorder(IGridXZ<bool> grid, int x, int z)
        {
            return x < padding
                || x >= grid.Width - padding
                || z < padding
                || z >= grid.Depth - padding;
        }
    }
}