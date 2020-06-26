using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Scheduler
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? RecallDate { get; set; }
        public string MsgContent { get; set; }
        public bool? IsActive { get; set; }
    }
}
