using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
