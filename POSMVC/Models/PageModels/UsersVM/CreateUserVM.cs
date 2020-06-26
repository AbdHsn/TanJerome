using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.UsersVM
{
    public class CreateUserVM
    {
        public Users Users { get; set; }
        public PersonalDetail PersonalDetail { get; set; }

        #region Extra Properties
        public IFormFile file { get; set; }
        #endregion

    }
}
