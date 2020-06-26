using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Health
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string ChiefComplain { get; set; }
        public string CaseHistory { get; set; }
        public string HealthMedication { get; set; }
        public string ContactLenseWorn { get; set; }
        public string PupilSize { get; set; }
        public string Rdim { get; set; }
        public string Ldim { get; set; }
        public string Rbright { get; set; }
        public string Lbright { get; set; }
        public string HealthCondition { get; set; }
        public string OralMedication { get; set; }
        public string Eyelids { get; set; }
        public string Lacrimation { get; set; }
        public string Blink { get; set; }
        public string EyeHealth { get; set; }
        public string Aperture { get; set; }
        public string Hvid { get; set; }
        public string ColorVision { get; set; }
        public string RpalpAperture { get; set; }
        public string LpalpAperture { get; set; }
        public string Rhvid { get; set; }
        public string Lhvid { get; set; }
        public string ReyeImagePath { get; set; }
        public string LeyeImagePath { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
