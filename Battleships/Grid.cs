using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class Grid
    {
        private const int Size = 4;
        private readonly Cell[,] _cells = new Cell[Size, Size];
        private int _numberOfShips = 0;

        public Grid()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }

        public void PlaceShipOnBoard(int x, int y, int length, Orientation orientation)
        {
            ValidateOutOfBounds(x, y);
            ValidateShipFits(x, y, length, orientation);
            ValidateNoOverlap(x, y, length, orientation);
            _numberOfShips++;

            if (Orientation.Vertical == orientation)
            {
                for (var i = 0; i < length; i++)
                {
                    _cells[x + i, y].ShipNumber = _numberOfShips;
                }
            }
            else
            {
                for (var i = 0; i < length; i++)
                {
                    _cells[x, y + i].ShipNumber = _numberOfShips;
                }
            }
        }

        public void PrintGrid()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    Console.Write($"{_cells[i, j].ShipNumber} ");
                }
                Console.WriteLine();
            }
        }

        public string Attack(int x, int y)
        {
            ValidateOutOfBounds(x, y);
            if (_cells[x, y].ShipNumber == 0)
            {
                return "Miss";
            }
            else
            {
                _cells[x, y].IsHit = true;
                var shipNumber = _cells[x, y].ShipNumber;
                for (var i = 0; i < Size; i++)
                {
                    for (var j = 0; j < Size; j++)
                    {
                        if (_cells[i, j].ShipNumber == shipNumber && !_cells[i, j].IsHit) return "Hit";
                    }
                }
            }
            return "Sink";
        }

        private static void ValidateOutOfBounds(int x, int y)
        {
            if (x < 0) throw new ArgumentOutOfRangeException("X value is less than 0 - can't go there!");
            if (x >= Size) throw new ArgumentOutOfRangeException($"X value is greater than {Size} - can't go there!");
            if (y < 0) throw new ArgumentOutOfRangeException("Y value is less than 0 - can't go there!");
            if (y >= Size) throw new ArgumentOutOfRangeException($"Y value is greater than {Size} - can't go there!");
        }

        private static void ValidateShipFits(int x, int y, int length, Orientation orientation)
        {
            if (Orientation.Vertical == orientation)
            {
                if (x + length > Size) throw new ArgumentException("Uh-oh! Ship can't fit on the board.");
            }
            else
            {
                if (y + length > Size) throw new ArgumentException("Uh-oh! Ship can't fit on the board.");
            }
        }

        private void ValidateNoOverlap(int x, int y, int length, Orientation orientation)
        {
            if (Orientation.Vertical == orientation)
            {
                for (var i = 0; i < length; i++)
                {
                    var shipNumber = _cells[x + i, y].ShipNumber;
                    if (shipNumber > 0) throw new ArgumentException($"Uh-oh! Ship is overlapping with ship {shipNumber} at cell [{x + i}, {y}]");
                }
            }
            else
            {
                for (var i = 0; i < length; i++)
                {
                    var xxx = _cells[x, y + i];
                    var shipNumber = _cells[x, y + i].ShipNumber;
                    if (shipNumber > 0) throw new ArgumentException($"Uh-oh! Ship is overlapping with ship {shipNumber} at cell [{x}, {y + i}]");
                }
            }
        }

    }
}
