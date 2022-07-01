using System;
using UnityFoundation.SavingSystem;

namespace GameAssets.BasicMazeGenerator
{
    public class MazeRepository
    {
        private readonly IGameFileSaver fileSaver;

        public MazeRepository(IGameFileSaver fileSaver)
        {
            this.fileSaver = fileSaver;
        }

        public void Save(string mazeName, Maze maze)
        {
            fileSaver.Save(mazeName, maze.GetData());
        }

        public Maze Load(string mazeName)
        {
            var obj = fileSaver.Load<Maze.Data>(mazeName);
            if(obj == null)
                throw new ArgumentException($"{mazeName} was not found");

            return new Maze(obj);
        }
    }
}
