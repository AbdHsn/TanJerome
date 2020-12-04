using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Users
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int? UserTypeId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TempField { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public string MobileNo { get; set; }
        public string OtherContactNo { get; set; }

        public virtual PersonalDetail PersonalDetail { get; set; }
    }
}
