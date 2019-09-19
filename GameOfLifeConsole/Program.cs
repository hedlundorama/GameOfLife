using System;
using System.Threading;
using GOL;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var gol = new GameOfLife(50,150);
            gol.Randomize();
            
            while (true)
            {
                Thread.Sleep(75);
                PrintBoard(gol.GetNextGeneration());
            }
        }

        private static void PrintBoard(GameOfLifeGeneration generation)
        {
            Console.Clear();
            Console.WriteLine($"Generation {generation.Generation}");
            for(int x = 0; x < generation.Board.GetLength(0); x++)
            {
                for(int y = 0; y < generation.Board.GetLength(1); y++)
                {
                    Console.Write(generation.Board[x,y] == 0 ? '.' : 'X');
                }
                Console.WriteLine();
            }
        }
    }
}