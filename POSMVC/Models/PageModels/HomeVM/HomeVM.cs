using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.HomeVM
{
    public class HomeVM
    {
        public List<ListProduct> ListProducts { get; set; }
    }

    #region "Product List Segment: Start"
    public class ListProduct
    {
        public Products Product { get; set; }
        public ProductImage ProductImage { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
    #endregion "Product List Segment: End"

}
