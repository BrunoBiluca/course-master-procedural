using UnityEngine;
using UnityFoundation.Code;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public class CubeGridRenderer : IGridRender
    {
        public static string OBJECT_NAME => "grid_cube";

        public void Render(IGridXZ<bool> grid)
        {
            foreach(var pos in grid.GridArray)
            {
                if(pos.Value) continue;

                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.name = OBJECT_NAME;
                go.transform.position = GridPositionXZMapper.ToVector3(pos);
            }
        }
    }
}