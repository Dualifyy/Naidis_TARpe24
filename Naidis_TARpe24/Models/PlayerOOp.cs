using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models
{
    public class PlayerOOp
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public PlayerOOp(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
