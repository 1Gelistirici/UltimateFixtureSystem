using System;

namespace UltimateAPI.Entities
{
    public class Message:BaseProperty
    {
        public string MessageDetail{ get; set; }
        public DateTime Time { get; set; }
    }
}
