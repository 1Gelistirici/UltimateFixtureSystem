using System;

namespace UltimateAPI.Entities
{
    public class Bill : BaseProperty
    {
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime InsertDate { get; set; }
        public Double Price { get; set; }
        public string Comment { get; set; }
        public int TypeNo { get; set; }
        public int Department { get; set; }
    }
}
