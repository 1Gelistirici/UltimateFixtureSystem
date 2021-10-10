using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.Entities
{
    public class Bill:BaseProperty
    {
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public Double Price{ get; set; }
        public string Comment{ get; set; }
        public string Product { get; set; }
        public int Piece{ get; set; }
        public string TypeNo { get; set; }
    }
}
