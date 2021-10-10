using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateDemerbas.Entities
{
    public class License:BaseProperty
    {
        public string Type { get; set; }
        public string TypeNo { get; set; }
        public int Piece { get; set; }

    }
}
