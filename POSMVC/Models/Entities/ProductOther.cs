using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class ProductOther
    {
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? MinSellingPrice { get; set; }
        public decimal? MemberPrice { get; set; }
        public decimal? WholesalePrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public bool? IsActive { get; set; }
        public string Metatag { get; set; }
    }
}
