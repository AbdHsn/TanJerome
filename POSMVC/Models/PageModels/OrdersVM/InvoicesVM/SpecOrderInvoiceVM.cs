using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM.SpecOrderInvoice
{
    public class SpecOrderInvoiceVM
    {

        #region Customer Properties
        public Users User { get; set; }
        public PersonalDetail PersonalDetail { get; set; }
        #endregion
        
        #region ContactLenseRX Properties
        public SpectacleRx Spectacle { get; set; }
        #endregion

        #region Order and Order Detail Properties
        public Orders Order { get; set; }
        public List<ListOfOrderDetail> ListOrderDetails { get; set; }
        public byte[] QrCode { get; set; }
        #endregion

    }

    public class ListOfOrderDetail
    {
        public Products Product { get; set; }
        public OrderDetails OrderDetail { get; set; }
    }
}
