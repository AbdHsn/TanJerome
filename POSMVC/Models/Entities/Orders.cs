using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            SalesTransaction = new HashSet<SalesTransaction>();
        }

        public long Id { get; set; }
        public string OrderNo { get; set; }
        public long? CustomerId { get; set; }
        public int? VatId { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? VatAmount { get; set; }
        public int? DiscountId { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? FinalTotal { get; set; }
        public string BillingAddress { get; set; }
        public DateTime? OrderPlaceDate { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string OrderStatus { get; set; }
        public string Note { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Discounts Discount { get; set; }
        public virtual Vat Vat { get; set; }
        public virtual ICollection<SalesTransaction> SalesTransaction { get; set; }
    }
}
