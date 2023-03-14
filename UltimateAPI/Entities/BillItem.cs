using System;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Entities
{
    public class BillItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Piece { get; set; }
        public Double Price { get; set; }
        public ProductType ProductType { get; set; }
        public int ModelRefId { get; set; }
        public int CategoryRefId { get; set; }

    }
}
