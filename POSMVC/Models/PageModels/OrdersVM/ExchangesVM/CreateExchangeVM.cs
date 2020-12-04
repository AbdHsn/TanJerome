using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM.ExchangesVM
{
    public class CreateExchangeVM
    {
        public Orders Order { get; set; }
        public Users User { get; set; }
        public PersonalDetail PersonalDetail { get; set; }
        public List<ListReturnableItem> lstReturnableItems { get; set; }

    }
    
    public class ListReturnableItem
    {
        public OrderDetails OrderDetails { get; set; }
        //public OrderReturnDetails OrderReturnDetails { get; set; }
        public Products Products { get; set; }
        public int ReturnableQuantity { get; set; }
        public int PreviousQuantity { get; set; }
    }



}
