using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class PaymentMethods
    {
        public PaymentMethods()
        {
            SalesTransaction = new HashSet<SalesTransaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public virtual ICollection<SalesTransaction> SalesTransaction { get; set; }
    }
}
