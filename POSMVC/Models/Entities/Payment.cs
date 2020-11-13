using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Payment
    {
        public long Id { get; set; }
        public string TransactionNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public long? UserId { get; set; }
        public string InstrumentNo { get; set; }
        public string TableReference { get; set; }
        public decimal? PaidAmount { get; set; }
        public int? PaymentMethodId { get; set; }
    }
}
