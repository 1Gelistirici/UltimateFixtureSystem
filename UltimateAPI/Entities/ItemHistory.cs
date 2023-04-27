using System;
using UltimateAPI.Entities.Enums;
using UltimateDemerbas.Models;

namespace UltimateAPI.Entities
{
    public class ItemHistory
    {
        public int Id { get; set; }
        public int ItemRefId { get; set; }
        public ItemType ItemType { get; set; }
        public TextValue ItemTypeTextValue { get; set; }
        public ProcessType ProcessType { get; set; }
        public TextValue ProcessTypeTextValue { get; set; }
        public int TransactionUserRefId { get; set; }
        public User TransactionUser { get; set; }
        public int CommittedUserRefId { get; set; }
        public User CommittedUser { get; set; }
        public DateTime InsertDate { get; set; }
        public Accessory Accessory { get; set; }
        public Bill Bill { get; set; }
        public Component Component { get; set; }
        public License Licence { get; set; }
        public Toner Toner { get; set; }
        public Fixture Fixture { get; set; }
    }
}
