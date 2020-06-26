using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class StockTrace
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public int? CurrentQuantity { get; set; }
        public int? OpeningQuantity { get; set; }
        public int? ClosingQuantity { get; set; }
        public string ReferenceId { get; set; }
        public string TableReference { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
