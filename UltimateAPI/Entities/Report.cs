using System;

namespace UltimateAPI.Entities
{
    public class Report : BaseProperty
    {
        public string ReportSubject { get; set; }
        public string ReportDetail { get; set; }
        public DateTime InsertDate { get; set; }
        public int ItemKind { get; set; }
        public int ItemId { get; set; }
    }
}
