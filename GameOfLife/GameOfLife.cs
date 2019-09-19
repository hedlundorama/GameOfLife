using System;

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
            _board = new byte[x,y];
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
            for(int i = 0; i < _sizeX; i++)
            {
                for(int j = 0; j < _sizeY; j++)
                {
                    _board[i, j] = (byte)rand.Next(0, 2);
                }
            }
        }

        public GameOfLifeGeneration GetCurrentGeneration()
        {
            return new GameOfLifeGeneration() { Board = _board, Generation = _generation };
        }

        public GameOfLifeGeneration GetNextGeneration()
        {
            var boardNext = new byte[_sizeX, _sizeY]; 

            for(int x = 0; x < _sizeX; x++)
            {
                for(int y = 0; y < _sizeY; y++)
                {
                    var neighbours = Neighbours(x,y);

                    if(_board[x,y] == 0)
                    {
                        if(neighbours == 3) boardNext[x,y] = 1;
                    }

                    if(_board[x, y] != 1) continue;
                    if(neighbours < 2) boardNext[x,y] = 0;
                    if(neighbours == 2 || neighbours == 3) boardNext[x,y] = 1;
                    if(neighbours > 3) boardNext[x,y] = 0;
                }
            }
            _board = boardNext;
            _generation++;
            
            return new GameOfLifeGeneration() { Board = _board, Generation = _generation };
        }

        private byte Neighbours(int posX, int posY)
        {
            byte neighbours = 0;
            for(int x = -1; x < 2; x++)
            {
                if(posX+x < 0 || posX+x == _sizeX) continue;

                for(int y = -1; y < 2; y++)
                {
                    if(x == 0 && y == 0) continue;
                    if(posY+y < 0 || posY+y == _sizeY) continue;

                    neighbours += _board[posX+x, posY+y];
                }
            }

            return neighbours;
        }
    }

    public struct GameOfLifeGeneration
    {
        public byte[,] Board;
        public int Generation;
    }
}