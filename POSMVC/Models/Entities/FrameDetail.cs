using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class FrameDetail
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Type { get; set; }
        public string ColorCode { get; set; }
        public string Size { get; set; }
    }
}
