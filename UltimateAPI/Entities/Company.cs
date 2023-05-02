using System;

namespace UltimateAPI.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime EstablishmentDate { get; set; }
    }
}
