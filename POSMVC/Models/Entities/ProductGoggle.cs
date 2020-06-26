using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class ProductGoggle
    {
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public long? ManufacturerId { get; set; }
        public int? BrandId { get; set; }
        public string Type { get; set; }
        public string FrameColor { get; set; }
        public string LenseColor { get; set; }
        public string Features { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Style { get; set; }
        public string FaceShap { get; set; }
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

        public virtual Brand Brand { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
