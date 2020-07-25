using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM
{
    public class PaymentsVM
    {
        public List<paymentDetail> ListPayments { get; set; }
        public Orders Orders { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal DueAmount { get; set; }
    }

    public class paymentDetail 
    {
        public Payment Payment { get; set; }
        public PaymentMethods paymentMethods { get; set; }
    }
}
