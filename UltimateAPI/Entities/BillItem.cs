using System;

namespace UltimateAPI.Entities
{
    public class BillItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Piece { get; set; }
        public Double Price { get; set; }
        public int ProductTypeRefId { get; set; }
        public int ModelRefId { get; set; }
        public int CategoryRefId { get; set; }

    }
}
