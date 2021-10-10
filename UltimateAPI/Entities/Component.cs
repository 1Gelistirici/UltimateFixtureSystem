using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.Entities
{
    public class Component : BaseProperty
    {
        public int Piece { get; set; }
        public string ModelNo { get; set; }
        public int BillNo { get; set; }
        public string CategoryNo { get; set; }
    }
}
