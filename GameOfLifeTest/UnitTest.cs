using NUnit.Framework;
using GOL;

namespace GameOfLifeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSetPosition()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(5,5);
            gol.SetPosition(6,5);
            gol.SetPosition(7,5);

            var gen = gol.GetCurrentGeneration();
            
            Assert.AreEqual(1,gen.Board[5,5]);
            Assert.AreEqual(1,gen.Board[6,5]);
            Assert.AreEqual(1,gen.Board[7,5]);
        }
        
        [Test]
        public void TestClearPosition()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(5,5);

            var gen = gol.GetCurrentGeneration();
            Assert.AreEqual(1,gen.Board[5,5]);
            
            gol.ClearPosition(5,5);
            gen = gol.GetCurrentGeneration();
            Assert.AreEqual(0,gen.Board[5,5]);
        }
        
        [Test]
        public void TestDeadCellWithThreeNeighbours()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(5,5);
            gol.SetPosition(6,5);
            gol.SetPosition(7,5);

            var gen = gol.GetNextGeneration();
            Assert.AreEqual(1,gen.Generation);
            Assert.AreEqual(1,gen.Board[6,4]);
        }
        
        [Test]
        public void TestAliveCellWithOneNeighbour()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(5,5);
            gol.SetPosition(6,5);

            var gen = gol.GetNextGeneration();
            Assert.AreEqual(1,gen.Generation);
            Assert.AreEqual(0,gen.Board[5,5]);
        }
        
        [Test]
        public void TestAliveCellWithTwoNeighbours()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(6,5);
            gol.SetPosition(7,5);
            gol.SetPosition(6,4);

            var gen = gol.GetNextGeneration();
            Assert.AreEqual(1,gen.Generation);
            Assert.AreEqual(1,gen.Board[6,4]);
        }
        
        [Test]
        public void TestAliveCellWithThreeNeighbours()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(5,5);
            gol.SetPosition(6,5);
            gol.SetPosition(7,5);
            gol.SetPosition(6,4);

            var gen = gol.GetNextGeneration();
            Assert.AreEqual(1,gen.Generation);
            Assert.AreEqual(1,gen.Board[6,4]);
        }
        
        [Test]
        public void TestAliveCellWithFourNeighbours()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(5,5);
            gol.SetPosition(6,5);
            gol.SetPosition(7,5);
            gol.SetPosition(6,4);
            gol.SetPosition(7,4);

            var gen = gol.GetNextGeneration();
            Assert.AreEqual(1,gen.Generation);
            Assert.AreEqual(0,gen.Board[6,4]);
        }
    }
}