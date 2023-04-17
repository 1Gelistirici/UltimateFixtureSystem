﻿using System;

namespace UltimateAPI.Entities
{
    public class Accessory : BaseProperty
    {
        public int Piece { get; set; }
        public int ModelNo { get; set; }
        public int UserNo { get; set; }
        public int BillNo { get; set; }
        public int StatuNo { get; set; }
        public int CategoryNo { get; set; }
        public Double Price { get; set; }
        public int CompanyRefId { get; set; }
    }
}
