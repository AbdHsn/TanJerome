using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM
{
    public class CreateSpecOrderVM
    {
        #region Customer Properties
        public Users Users { get; set; }
        public UserType UserType { get; set; }
        public PersonalDetail PersonalDetail { get; set; }

        #endregion
        
        #region Product Properties
        public Products Products { get; set; }

        #endregion
        
        #region Order and Order Detail Properties
        public Orders Order { get; set; }
        public OrderDetails OrderDetails { get; set; }

        public List<OrderDetails> ListOrderDetails { get; set; }

        #endregion

        #region Contact Lense Properties
        public SpectacleRx SpectacleRx { get; set; }

        #endregion


    }
}
