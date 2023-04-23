using System;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Entities
{
    public class Report : BaseProperty
    {
        public string ReportSubject { get; set; }
        public string ReportDetail { get; set; }
        public DateTime InsertDate { get; set; }
        public ItemType ItemType { get; set; }
        public int ItemId { get; set; }
        public string Comment { get; set; }
        public int Statu { get; set; }
        public int AssignmentId { get; set; }
        public Accessory AccessoryItem { get; set; }
        public Bill BillItem { get; set; }
        public Component ComponentItem { get; set; }
        public License LicenceItem { get; set; }
        public Toner TonerItem { get; set; }
        public Fixture FixtureItem { get; set; }
    }
}
