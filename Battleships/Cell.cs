using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class Cell
    {
        public int ShipNumber { get; set; } = 0;
        public bool IsHit { get; set; } = false;
    }
}
