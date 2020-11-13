using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Manufacturer
    {
        public long Id { get; set; }
        public string ManufacturerName { get; set; }
        public string ContactInfo { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Url { get; set; }
    }
}
