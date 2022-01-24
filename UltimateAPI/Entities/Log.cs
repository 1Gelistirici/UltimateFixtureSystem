using System;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Entities
{
    public class Log : BaseProperty
    {
        public string Detail { get; set; }
        public string Icon { get; set; }
        public string IncorrectPassword { get; set; }
        public string IncorrectUserName { get; set; }
        public DateTime Time { get; set; }
        public int UserNo { get; set; }
        public LogType Type { get; set; }
    }
}
