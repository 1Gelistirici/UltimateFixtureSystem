using System;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Entities
{
    public class Tasks:BaseProperty
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IsActive IsActive { get; set; }
        public int Count { get; set; }
        public string TaskDetail { get; set; }
    }
}
