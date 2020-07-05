using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class OrderDetails
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CollectionDate { get; set; }
        public int? VatId { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? VatAmount { get; set; }
        public int? DiscountId { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? Total { get; set; }
    }
}
