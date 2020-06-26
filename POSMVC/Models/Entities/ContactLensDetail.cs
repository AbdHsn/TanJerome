using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class ContactLensDetail
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Bc { get; set; }
        public string Diameter { get; set; }
        public string Features { get; set; }
    }
}
