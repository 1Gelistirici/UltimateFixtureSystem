using System;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Entities
{
    public class Tasks : BaseProperty
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActiveStatu IsActive { get; set; }
        public int Count { get; set; }
        public string TaskDetail { get; set; }
        public string Note { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
