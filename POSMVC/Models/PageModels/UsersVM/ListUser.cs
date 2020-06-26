using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.UsersVM
{
    public class ListUser
    {
        public Users User { get; set; }
        public UserType UserType { get; set; }
        public PersonalDetail PersonalDetail { get; set; }
    }
}
