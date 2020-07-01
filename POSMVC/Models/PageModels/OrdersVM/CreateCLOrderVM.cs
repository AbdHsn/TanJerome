using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM
{
    public class CreateCLOrderVM
    {
        #region Customer Properties
        public Users Users { get; set; }
        public PersonalDetail PersonalDetail { get; set; }

        #endregion
        
        #region Product Properties
        public Products Products { get; set; }

        #endregion
        
        #region Contact Lense Properties
        public ContactLenseRx ContactLense { get; set; }

        #endregion


    }
}
