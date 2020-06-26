using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Purchase
    {
        public long Id { get; set; }
        public string PurchaseNo { get; set; }
        public int? SupplierId { get; set; }
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? VatId { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? PriceRate { get; set; }
        public decimal? FinalTotal { get; set; }
        public string Note { get; set; }
    }
}
