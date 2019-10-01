using System;
using System.Diagnostics;
using System.Threading;
using GOL;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Randomizing");
            var gol = new GameOfLife(1000,1000);
            gol.Randomize();

            Console.WriteLine("Starting simulation");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                _ = gol.GetNextGeneration();
            }
            stopWatch.Stop();
            
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            
            //while (true)
            //{
                //Thread.Sleep(75);
                //PrintBoard(gol.GetNextGeneration());
            //}
        }

        private static void PrintBoard(GameOfLifeGeneration generation)
        {
            Console.Clear();
            Console.WriteLine($"Generation {generation.Generation}");
            for(int y = 0; y < generation.Board.GetLength(1); y++)
            {
                for(int x = 0; x < generation.Board.GetLength(0); x++)
                {
                    Console.Write(generation.Board[x,y] == 0 ? '.' : 'X');
                }
                Console.WriteLine();
            }
        }
    }
}