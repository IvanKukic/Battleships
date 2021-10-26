using System;
using System.Security.Cryptography.X509Certificates;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid();

            //show length validation
            //grid.PlaceShipOnBoard(0, 0, 5, Orientation.Horizontal

            grid.PlaceShipOnBoard(1, 0, 2, Orientation.Horizontal);
            grid.PlaceShipOnBoard(2, 0, 2, Orientation.Vertical);
            grid.PlaceShipOnBoard(0, 3, 3, Orientation.Vertical);
            grid.PrintGrid();

            //show out of bounds validation
            //grid.PlaceShipOnBoard(-1, 2, 3, Orientation.Vertical);
            //grid.PlaceShipOnBoard(0, 5, 3, Orientation.Vertical);

            //show overlap validation
            //grid.PlaceShipOnBoard(0, 0, 2, Orientation.Vertical);

            Console.WriteLine(grid.Attack(0, 0));
            Console.WriteLine(grid.Attack(1, 0));
            Console.WriteLine(grid.Attack(1, 1));
            Console.WriteLine(grid.Attack(2, 3));
        }
    }
}
