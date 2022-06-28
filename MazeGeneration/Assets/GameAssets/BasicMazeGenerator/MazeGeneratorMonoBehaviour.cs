using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public class MazeGeneratorMonoBehaviour : MonoBehaviour
    {
        public void Start()
        {
            var grid = new GridXZ<bool>(20, 20, 1) { ForceSetValue = true };
            var maze = new BasicMazeGenerator(grid);

            maze.Generate(
                new RandomCrawler(new UnityRandomGenerator())
                    .SetBorderPadding(1)
            );
            maze.Generate(new StraightCrawler(3));

            maze.Render(new CubeGridRenderer());
        }
    }
}