using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Balance
    {
        public int Id { get; set; }
        public int? SourceTypeId { get; set; }
        public decimal? Amount { get; set; }
    }
}
