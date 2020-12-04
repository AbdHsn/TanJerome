using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.PaymentsVM
{
    public class GetTransactionVM
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string OrderNo { get; set; }
        public int TotalRecords { get; set; }
        public decimal TotalPaid { get; set; }

        public Company Company { get; set; }
        public List<ListPayment> lstPayment { get; set; }

        public class ListPayment
        {
            public Orders Order { get; set; }
            public Users User { get; set; }
            public Payment Payment { get; set; }
        }
    }
}
