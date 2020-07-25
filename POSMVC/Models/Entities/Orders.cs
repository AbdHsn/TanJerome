using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Orders
    {
        public long Id { get; set; }
        public string OrderNo { get; set; }
        public long? UserId { get; set; }
        public int? VatId { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? VatAmount { get; set; }
        public int? DiscountId { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? GrandTotal { get; set; }
        public string BillingAddress { get; set; }
        public DateTime? OrderPlaceDate { get; set; }
        public DateTime? CollectionDate { get; set; }
        public long? UpdateBy { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string OrderStatus { get; set; }
        public string Note { get; set; }
    }
}
