using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateDemerbas.Entities
{
    public class Message : BaseProperty
    {
        public string MessageDetail { get; set; }
        public DateTime Time { get; set; }
    }
}
