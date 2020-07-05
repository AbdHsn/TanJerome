using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Discounts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? DiscountRate { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
