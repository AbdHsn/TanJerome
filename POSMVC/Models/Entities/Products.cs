using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Products
    {
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int? ProductTypeId { get; set; }
        public int? BrandId { get; set; }
        public long? ManufacturerId { get; set; }
        public string Type { get; set; }
        public string ColorCode { get; set; }
        public string Size { get; set; }
        public string Bc { get; set; }
        public string Diameter { get; set; }
        public string Description { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string MetaTags { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
