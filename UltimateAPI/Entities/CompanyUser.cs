using System;

namespace UltimateAPI.Entities
{
    public class CompanyUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
