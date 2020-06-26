using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class SunglassDetail
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string FrameColor { get; set; }
        public string LenseColor { get; set; }
        public string Features { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Style { get; set; }
        public string FaceShap { get; set; }
    }
}
