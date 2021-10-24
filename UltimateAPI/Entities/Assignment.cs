using System;

namespace UltimateAPI.Entities
{
    public class Assignment:BaseProperty
    {
        public int AppointerId { get; set; }
        public int ItemType { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime RecallDate { get; set; }
    }
}
