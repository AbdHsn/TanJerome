using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class UnitMeasurement
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
    }
}
