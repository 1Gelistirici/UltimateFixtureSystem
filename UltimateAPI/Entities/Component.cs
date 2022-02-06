using System;

namespace UltimateAPI.Entities
{
    public class Component : BaseProperty
    {
        public int Piece { get; set; }
        public Double Price { get; set; }
        public string ModelNo { get; set; }
        public int BillNo { get; set; }
        public string CategoryNo { get; set; }
    }
}
