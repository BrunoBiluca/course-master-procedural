using UnityEngine;
using UnityFoundation.Code;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{
    public class MazeGeneratorMonoBehaviour : MonoBehaviour
    {
        public void Start()
        {
            var maze = new BasicMazeGenerator(20, 20)
                .AddCrawler(
                    new RandomCrawlerOnDepth(new UnityRandomGenerator())
                        .SetBorderPadding(1)
                )
                .AddCrawler(new StraightCrawler(3))
                .Generate();

            new CubeGridRenderer().Render(maze);
        }
    }
}