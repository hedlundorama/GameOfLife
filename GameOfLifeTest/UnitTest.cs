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
        public void TestNextGeneration()
        {
            var gol = new GameOfLife(10,10);
            gol.SetPosition(5,5);
            gol.SetPosition(6,5);
            gol.SetPosition(7,5);

            var gen = gol.GetNextGeneration();
            Assert.AreEqual(1,gen.Generation);
            Assert.AreEqual(0,gen.Board[5,5]);
            Assert.AreEqual(0,gen.Board[7,5]);
            Assert.AreEqual(1,gen.Board[6,4]);
            Assert.AreEqual(1,gen.Board[6,5]);
            Assert.AreEqual(1,gen.Board[6,6]);
        }
    }
}