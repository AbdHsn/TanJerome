using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Refunds
    {
        public long Id { get; set; }
        public long? SalesReturnId { get; set; }
        public string RefundNo { get; set; }
        public string SalesReturnNo { get; set; }
        public decimal? RefundAmount { get; set; }
        public DateTime? RefundedDate { get; set; }
        public long? RefundedBy { get; set; }

        public virtual SalesReturn SalesReturn { get; set; }
    }
}
