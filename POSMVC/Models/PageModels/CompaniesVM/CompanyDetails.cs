using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.CompaniesVM
{
    public class CompanyDetails
    {
        public Company Company { get; set; }
        public IFormFile ActualCompanyLogo { get; set; }
        public bool ImageClearActive { get; set; }
    }
}
