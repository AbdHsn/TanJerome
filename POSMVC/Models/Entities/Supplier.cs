using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
    }
}
