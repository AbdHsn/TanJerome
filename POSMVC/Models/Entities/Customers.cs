using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            ContactLenseRx = new HashSet<ContactLenseRx>();
            Health = new HashSet<Health>();
            HealthDocument = new HashSet<HealthDocument>();
            Orders = new HashSet<Orders>();
            SalesReturn = new HashSet<SalesReturn>();
            SalesTransaction = new HashSet<SalesTransaction>();
            SpectacleRx = new HashSet<SpectacleRx>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Icno { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? PostalCode { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ContactLenseRx> ContactLenseRx { get; set; }
        public virtual ICollection<Health> Health { get; set; }
        public virtual ICollection<HealthDocument> HealthDocument { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<SalesReturn> SalesReturn { get; set; }
        public virtual ICollection<SalesTransaction> SalesTransaction { get; set; }
        public virtual ICollection<SpectacleRx> SpectacleRx { get; set; }
    }
}
