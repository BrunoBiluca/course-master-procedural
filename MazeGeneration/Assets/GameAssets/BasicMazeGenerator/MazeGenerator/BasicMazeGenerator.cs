using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityFoundation.Code.Grid;

namespace GameAssets.BasicMazeGenerator
{

    public class BasicMazeGenerator
    {
        private readonly Maze maze;
        private readonly List<IGridCrawler> crawlers;
        public bool WasMazeGenerated { get; private set; }

        public BasicMazeGenerator(int width, int depth)
        {
            WasMazeGenerated = false;
            crawlers = new List<IGridCrawler>();

            maze = new Maze(width, depth, 1) { ForceSetValue = true };
            maze.Fill(true);
        }

        public BasicMazeGenerator AddCrawler(IGridCrawler crawler)
        {
            crawlers.Add(crawler);
            return this;
        }

        public Maze GetMaze()
        {
            if(!WasMazeGenerated)
                throw new InvalidOperationException("Maze was not generated");

            return maze;
        }

        public Maze Generate()
        {
            foreach(var crawler in crawlers)
                crawler.Craw(maze);

            WasMazeGenerated = true;
            return maze;
        }
    }
}