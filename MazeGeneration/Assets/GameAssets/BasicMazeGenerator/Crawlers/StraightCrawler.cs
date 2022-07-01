using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public class StraightCrawler : IGridCrawler
    {
        private readonly int line;

        public StraightCrawler(int line)
        {
            this.line = line;
        }

        public void Craw(Maze maze, bool value = false)
        {
            foreach(var gridPos in maze.GridMatrix)
            {
                if(gridPos.Z == line)
                    gridPos.Value = value;
            }
        }
    }
}