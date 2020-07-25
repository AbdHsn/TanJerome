using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.OrdersVM
{
    public class OrdersVM
    {
        public Orders Orders { get; set; }
        public Users Users { get; set; }
        public UserType UserType { get; set; }
        public PersonalDetail PersonalDetail { get; set; }
        public  decimal PaidAmount { get; set; }
        public  decimal DueAmount { get; set; }
        public  String PaidStatus { get; set; }
    }
}
