using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Vat
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? VatRate { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
