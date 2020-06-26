using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class PurchaseReturn
    {
        public long Id { get; set; }
        public string PurchaseReturnNo { get; set; }
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Reason { get; set; }
    }
}
