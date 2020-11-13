using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.PaymentsVM
{
    public class GetPaymentDetailsVM
    {
        public Orders Order { get; set; }
        public Users User { get; set; }
        
        public PersonalDetail PersonalDetail { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Due { get; set; }
        public decimal PayAmount { get; set; }
        public int PaymentMethodId { get; set; }

        public IQueryable<ListPayments> lstPayment { get; set; }
        public IQueryable<ListOrderDetails> lstOrderDetails { get; set; }

    }
    
    public class ListPayments
    {
        public Payment Payment { get; set; }
        public PaymentMethods PaymentMethods { get; set; }

    }
    
    public class ListOrderDetails
    {
        public OrderDetails OrderDetails { get; set; }
        public Products Products { get; set; }
    }



}
