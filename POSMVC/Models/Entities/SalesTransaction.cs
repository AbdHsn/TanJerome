using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class SalesTransaction
    {
        public long Id { get; set; }
        public string SaleTransactionNo { get; set; }
        public long? OrderId { get; set; }
        public long? CustomerId { get; set; }
        public int? PaymentMethodId { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual PaymentMethods PaymentMethod { get; set; }
    }
}
