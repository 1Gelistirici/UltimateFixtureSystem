using System;
using UltimateAPI.Entities.Enums;
using UltimateDemerbas.Models;

namespace UltimateAPI.Entities
{
    public class Fixture : BaseProperty
    {
        public string LoginSystem { get; set; }
        public int ModelNo { get; set; }
        public FixtureModel Model { get; set; }
        public int BillNo { get; set; }
        public Bill Bill { get; set; }
        public int StatuNo { get; set; }
        public int CategoryNo { get; set; }
        public Category Category { get; set; }
        public int UserNo { get; set; }
        public Double Price { get; set; }
        public int CompanyRefId { get; set; }
        public TextValue ItemStatu { get; set; }
        public string QRCode { get; set; }
        public string Barcode { get; set; }
    }
}
