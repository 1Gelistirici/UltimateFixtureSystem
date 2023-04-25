using System;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Entities
{
    public class ItemHistory
    {
        public int Id { get; set; }
        public int ItemRefId { get; set; }
        public ItemType ItemType { get; set; }
        public ProcessType ProcessType { get; set; }
        public int TransactionUserRefId { get; set; }
        public int CommittedUserRefId { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
