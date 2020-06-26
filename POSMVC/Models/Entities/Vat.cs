using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Vat
    {
        public Vat()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? VatRate { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
