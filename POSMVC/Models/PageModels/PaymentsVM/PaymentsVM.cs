using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.PaymentsVM
{
    public class PaymentsVM
    {
        public long OrderId { get; set; }
        public string OrderNo { get; set; }
        public long UserId { get; set; }
        public decimal PaidAmount { get; set; }
        public int PaymentMethodId { get; set; }
        public string RedirectLink { get; set; }
    }
}
