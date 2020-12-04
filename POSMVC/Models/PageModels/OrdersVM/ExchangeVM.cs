using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;

namespace POSMVC.Models.PageModels.OrdersVM
{
    public class ExchangeVM
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string OrderNo { get; set; }
        public int TotalRecords { get; set; }
        public decimal TotalReturnAmount { get; set; }
        public decimal TotalEarnAmount { get; set; }

        public Company Company { get; set; }
        public List<ListExchange> lstExchange { get; set; }

        public class ListExchange
        {
            public Exchange Exchange { get; set; }
            public Orders Order { get; set; }
            public OrderReturn OrderReturn { get; set; }
            public Users User { get; set; }
        }
    }
}
