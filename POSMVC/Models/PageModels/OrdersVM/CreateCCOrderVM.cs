using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM
{
    public class CreateCCOrderVM
    {
        #region Customer Properties
        public Users Users { get; set; }
        public PersonalDetail PersonalDetail { get; set; }
        #endregion


        #region OrderDetail Properties
        public List<OrderDetails> ListOrderDetails { get; set; }

        #endregion

    }
}
