using System;
using System.Runtime.Serialization;

namespace GameAssets.BasicMazeGenerator
{
    public partial class Maze
    {
        [Serializable]
        public class Data
        {
            public int Width;
            public int Depth;
            public int CellSize;
            public Position[] Positions;
        }
    }
}