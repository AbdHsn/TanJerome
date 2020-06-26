using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class HealthDocument
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string DocumentName { get; set; }
        public string SavePath { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
