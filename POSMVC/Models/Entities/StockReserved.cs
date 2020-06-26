using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class StockReserved
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? CustomerId { get; set; }
        public int? ReservedQuantity { get; set; }
        public string ReserveStatus { get; set; }
        public string Note { get; set; }
    }
}
