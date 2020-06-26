using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class SalesReturn
    {
        public SalesReturn()
        {
            Refunds = new HashSet<Refunds>();
        }

        public long Id { get; set; }
        public string SalesReturnNo { get; set; }
        public string OrderNo { get; set; }
        public long? ProductId { get; set; }
        public long? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<Refunds> Refunds { get; set; }
    }
}
