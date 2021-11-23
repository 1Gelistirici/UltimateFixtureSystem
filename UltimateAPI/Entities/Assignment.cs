using System;

namespace UltimateAPI.Entities
{
    public class Assignment : BaseProperty
    {
        public int AppointerId { get; set; }
        public int ItemType { get; set; }
        public int ItemId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime RecallDate { get; set; }
        public int Piece { get; set; }
        public bool IsRecall { get; set; }
        public bool Report { get; set; }
        public Accessory Accessories { get; set; }
        public Bill Bills { get; set; }
        public Component Components { get; set; }
        public License Licences { get; set; }
        public Toner Toners { get; set; }

        //public Fixture Fixtures { get; set; }
    }
}
