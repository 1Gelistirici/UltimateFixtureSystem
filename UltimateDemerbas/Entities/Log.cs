using System;

namespace UltimateDemerbas.Entities
{
    public class Log:BaseProperty
    {
        public string UserName { get; set; }
        public string Detail { get; set; }
        public string Icon { get; set; }
        public DateTime Time { get; set; }
        public int UserNo { get; set; }
    }
}
