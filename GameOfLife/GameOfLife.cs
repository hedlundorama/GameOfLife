using System;
using System.Collections.Generic;

namespace GOL
{
    public class GameOfLife
    {
        private byte[,] _board;
        private readonly int _sizeX;
        private readonly int _sizeY;
        private int _generation;

        public GameOfLife(int x, int y)
        {
            _sizeX = x;
            _sizeY = y;
            _board = new byte[x, y];
            _generation = 0;
        }

        public void SetPosition(int x, int y)
        {
            _board[x, y] = 1;
        }

        public void ClearPosition(int x, int y)
        {
            _board[x, y] = 0;
        }

        public void Randomize()
        {
            var rand = new Random();
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    _board[i, j] = (byte) rand.Next(0, 2);
                }
            }
        }

        public GameOfLifeGeneration GetCurrentGeneration()
        {
            return new GameOfLifeGeneration() {Board = _board, Generation = _generation};
        }

        public GameOfLifeGeneration GetNextGeneration()
        {
            var boardNext = new byte[_sizeX, _sizeY];

            for (int x = 0; x < _sizeX; x++)
            {
                for (int y = 0; y < _sizeY; y++)
                {
                    var neighbours = Neighbours(x, y);

                    if (_board[x, y] == 0)
                    {
                        if (neighbours == 3) boardNext[x, y] = 1;
                    }

                    if (_board[x, y] != 1) continue;
                    if (neighbours < 2) boardNext[x, y] = 0;
                    if (neighbours == 2 || neighbours == 3) boardNext[x, y] = 1;
                    if (neighbours > 3) boardNext[x, y] = 0;
                }
            }

            _board = boardNext;
            _generation++;

            return new GameOfLifeGeneration() {Board = _board, Generation = _generation};
        }

        private byte Neighbours(int posX, int posY)
        {
            byte neighbours = 0;
            for (int x = -1; x < 2; x++)
            {
                if (posX + x < 0 || posX + x == _sizeX) continue;

                for (int y = -1; y < 2; y++)
                {
                    if (x == 0 && y == 0) continue;
                    if (posY + y < 0 || posY + y == _sizeY) continue;

                    neighbours += _board[posX + x, posY + y];
                }
            }

            return neighbours;
        }

        public void GosperGliderGun()
        {
            SetPosition(25,1);
            SetPosition(23,2);
            SetPosition(25,2);
            SetPosition(13,3);
            SetPosition(14,3);
            SetPosition(21,3);
            SetPosition(22,3);
            SetPosition(35,3);
            SetPosition(36,3);
            SetPosition(12,4);
            SetPosition(16,4);
            SetPosition(21,4);
            SetPosition(22,4);
            SetPosition(35,4);
            SetPosition(36,4);
            SetPosition(1,5);
            SetPosition(2,5);
            SetPosition(11,5);
            SetPosition(17,5);
            SetPosition(21,5);
            SetPosition(22,5);
            SetPosition(1,6);
            SetPosition(2,6);
            SetPosition(11,6);
            SetPosition(15,6);
            SetPosition(17,6);
            SetPosition(18,6);
            SetPosition(23,6);
            SetPosition(25,6);
            SetPosition(11,7);
            SetPosition(17,7);
            SetPosition(25,7);
            SetPosition(12,8);
            SetPosition(16,8);
            SetPosition(13,9);
            SetPosition(14,9);
        }

        public void Acorn()
        {
            SetPosition(50,23);
            SetPosition(52,24);
            SetPosition(49,25);
            SetPosition(50,25);
            SetPosition(53,25);
            SetPosition(54,25);
            SetPosition(55,25);
        }
	}

    public struct GameOfLifeGeneration
    {
        public byte[,] Board;
        public int Generation;
    }
}