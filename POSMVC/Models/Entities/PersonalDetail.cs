using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class PersonalDetail
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string OtherPhone { get; set; }
        public DateTime? Dob { get; set; }
        public string Address { get; set; }
        public string Language { get; set; }
        public string MaritalStatus { get; set; }

        public virtual Users User { get; set; }
    }
}
