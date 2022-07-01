using NUnit.Framework;
using System.Collections.Generic;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public partial class Maze : GridXZ<bool>
    {
        public Maze(int width, int height, int cellSize) : base(width, height, cellSize)
        {
        }

        public Maze(Data data) : base(data.Width, data.Depth, data.CellSize)
        {
            for(int x = 0; x < width; x++)
                for(int z = 0; z < height; z++)
                {
                    var pos = new GridPositionXZ<bool>(x, z);

                    int posIndex = GetIndex(x, z);
                    pos.Index = data.Positions[posIndex].Index;
                    pos.Value = data.Positions[posIndex].Value;
                    gridArray[x, z] = pos;
                }

        }

        public Data GetData()
        {
            var positions = new List<Position>();
            for(int x = 0; x < width; x++)
                for(int z = 0; z < height; z++)
                    positions.Add(new Position(gridArray[x, z]));

            return new Data() {
                Width = width,
                Depth = Depth,
                CellSize = CellSize,
                Positions = positions.ToArray()
            };
        }

        public int GetIndex(int x, int z)
        {
            return x * width + z;
        }
    }
}