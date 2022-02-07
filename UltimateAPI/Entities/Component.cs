using System;

namespace UltimateAPI.Entities
{
    public class Component : BaseProperty
    {
        public int Piece { get; set; }
        public Double Price { get; set; }
        public int ModelNo { get; set; }
        public int BillNo { get; set; }
        public int CategoryNo { get; set; }
    }
}
