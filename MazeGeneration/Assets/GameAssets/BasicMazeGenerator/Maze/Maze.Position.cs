using System;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public partial class Maze
    {
        [Serializable]
        public class Position
        {
            public int X;
            public int Z;
            public int Index;
            public bool Value;

            public Position(GridPositionXZ<bool> gridPositionXZ)
            {
                X = gridPositionXZ.X;
                Z = gridPositionXZ.Z;
                Index = gridPositionXZ.Index;
                Value = gridPositionXZ.Value;
            }
        }
    }
}