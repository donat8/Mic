﻿namespace Mic.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CatId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }


        public virtual Cat Cat { get; set; }

        public virtual Order Order { get; set; }

    }
}