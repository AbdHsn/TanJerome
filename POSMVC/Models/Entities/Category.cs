using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Category
    {
        public int Id { get; set; }
        public string ParentCategory { get; set; }
        public string SubCategory { get; set; }
        public bool? IsActive { get; set; }
    }
}
