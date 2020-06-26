using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string SmallLogo { get; set; }
        public string BigLogo { get; set; }
        public string RegistrationNo { get; set; }
    }
}
