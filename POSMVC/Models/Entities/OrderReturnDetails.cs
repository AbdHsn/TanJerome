using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class OrderReturnDetails
    {
        public long Id { get; set; }
        public long? ReturnId { get; set; }
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
