using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;

namespace POSMVC.Models.PageModels.ManufacturersVM
{
    public class CreateManufacturerVM
    {
        public Manufacturer Manufacturer { get; set; }

        #region Extra Properties
        public IFormFile file { get; set; }
        #endregion

    }
}
