using System;

namespace UltimateAPI.Entities
{
    public class UsedToner : BaseProperty
    {
        public int DepartmentNo { get; set; }
        public int TonerNo { get; set; }
        public int Piece { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
