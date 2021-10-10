using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.Entities
{
    public class Toner:BaseProperty
    {
        public int Piece { get; set; }
        public int Boundary { get; set; }
        public double Price { get; set; }
    }
}
