using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM
{
    public class OrderHistoryVM
    {
        public AllOrder Orders { get; set; }
        public Users Users { get; set; }
    }

    public class AllOrder {
        public Orders Order { get; set; }
        public Payment Payment { get; set; }
        public List<OrderDetailWithProduct> ListOrderDetails { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string PaidStatus { get; set; }

    }
    public class OrderDetailWithProduct {
        public Products Products { get; set; }
        public OrderDetails OrderDetails { get; set; }


    }
}
