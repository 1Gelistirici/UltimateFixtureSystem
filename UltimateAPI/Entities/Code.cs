using System;

namespace UltimateAPI.Entities
{
    public class Code
    {
        public int Id { get; set; }
        public int UserRefId { get; set; }
        public string SessionId { get; set; }
        public string CodeString { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string TryPassword { get; set; }
    }
}
