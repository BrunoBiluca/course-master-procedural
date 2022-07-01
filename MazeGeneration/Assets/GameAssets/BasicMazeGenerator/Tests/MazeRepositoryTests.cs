using NUnit.Framework;
using System;
using UnityFoundation.Code.Grid;
using UnityFoundation.SavingSystem;

namespace GameAssets.BasicMazeGenerator.Tests
{
    public class MazeRepositoryTests
    {
        [Test]
        public void ShouldNotLoadWhenMazeWasNotSaved()
        {
            var repository = new MazeRepository(new MemoryGameSaver());
            Assert.Throws<ArgumentException>(() => repository.Load("maze_test"));
        }

        [Test]
        public void ShouldSavedMaze()
        {
            var repository = new MazeRepository(new MemoryGameSaver());

            var inMaze = new BasicMazeGenerator(2, 2)
                .AddCrawler(new StraightCrawler(1))
                .Generate();

            repository.Save("maze_test", inMaze);

            var outMaze = repository.Load("maze_test");

            Assert.AreEqual(inMaze.GetValue(0, 0), outMaze.GetValue(0, 0));
            Assert.AreEqual(inMaze.GetValue(0, 1), outMaze.GetValue(0, 1));
            Assert.AreEqual(inMaze.GetValue(1, 0), outMaze.GetValue(1, 0));
            Assert.AreEqual(inMaze.GetValue(1, 1), outMaze.GetValue(1, 1));
        }

        [Test]
        public void ShouldSavedMultipleMazes()
        {
            var repository = new MazeRepository(new MemoryGameSaver());

            var inMaze = new BasicMazeGenerator(2, 2)
                .AddCrawler(new StraightCrawler(1))
                .Generate();

            repository.Save("maze_test_1", inMaze);
            repository.Save("maze_test_2", inMaze);

            var outMaze = repository.Load("maze_test_1");

            Assert.AreEqual(inMaze.GetValue(0, 0), outMaze.GetValue(0, 0));
            Assert.AreEqual(inMaze.GetValue(0, 1), outMaze.GetValue(0, 1));
            Assert.AreEqual(inMaze.GetValue(1, 0), outMaze.GetValue(1, 0));
            Assert.AreEqual(inMaze.GetValue(1, 1), outMaze.GetValue(1, 1));

            var outMaze2 = repository.Load("maze_test_2");

            Assert.AreEqual(inMaze.GetValue(0, 0), outMaze2.GetValue(0, 0));
            Assert.AreEqual(inMaze.GetValue(0, 1), outMaze2.GetValue(0, 1));
            Assert.AreEqual(inMaze.GetValue(1, 0), outMaze2.GetValue(1, 0));
            Assert.AreEqual(inMaze.GetValue(1, 1), outMaze2.GetValue(1, 1));
        }

        [Test]
        public void ShouldPersistMazeOnFile()
        {
            var repository = new MazeRepository(new BinaryGameFileSaver());

            var inMaze = new BasicMazeGenerator(300, 300)
                .AddCrawler(new StraightCrawler(1))
                .Generate();

            repository.Save("maze_test", inMaze);

            var outMaze = repository.Load("maze_test");

            Assert.AreEqual(inMaze.GetValue(0, 0), outMaze.GetValue(0, 0));
            Assert.AreEqual(inMaze.GetValue(0, 1), outMaze.GetValue(0, 1));
            Assert.AreEqual(inMaze.GetValue(1, 0), outMaze.GetValue(1, 0));
            Assert.AreEqual(inMaze.GetValue(1, 1), outMaze.GetValue(1, 1));
        }

        [Test]
        public void ShouldPersistMazeOnJsonFile()
        {
            var repository = new MazeRepository(new JsonGameFileSaver());

            var inMaze = new BasicMazeGenerator(300, 300)
                .AddCrawler(new StraightCrawler(1))
                .Generate();

            repository.Save("maze_test", inMaze);

            var outMaze = repository.Load("maze_test");

            Assert.AreEqual(inMaze.GetValue(0, 0), outMaze.GetValue(0, 0));
            Assert.AreEqual(inMaze.GetValue(0, 1), outMaze.GetValue(0, 1));
            Assert.AreEqual(inMaze.GetValue(1, 0), outMaze.GetValue(1, 0));
            Assert.AreEqual(inMaze.GetValue(1, 1), outMaze.GetValue(1, 1));
        }
    }
}