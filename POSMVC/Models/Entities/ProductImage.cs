using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class ProductImage
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string Title { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
    }
}
