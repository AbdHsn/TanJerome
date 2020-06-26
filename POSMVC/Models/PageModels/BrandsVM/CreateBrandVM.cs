using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.BrandsVM
{
    public class CreateBrandVM
    {
        public Brand Brand { get; set; }

        #region Extra Properties
        public IFormFile file { get; set; }
        #endregion

    }
}
