using Microsoft.AspNetCore.Http;
using POSMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSMVC.Models.PageModels.ItemVM
{
    public class CreateItem
    {
        #region Product Properties
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int? ProductTypeId { get; set; }
        public int? BrandId { get; set; }
        public long? ManufacturerId { get; set; }
        public string Description { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
        public string MetaTags { get; set; }
        #endregion

        #region Frame Properties
        public string FRGender { get; set; }
        public string FRModel { get; set; }
        public string FRSize { get; set; }
        public string FRColor { get; set; }
        public string FRMaterial { get; set; }
        public string FRShap { get; set; }
        #endregion

        #region ContactLens Properties
        public string CLType { get; set; }
        public string CLColor { get; set; }
        public string CLMaterial { get; set; }
        public string CLBc { get; set; }
        public string CLDiameter { get; set; }
        public string CLFeatures { get; set; }
        #endregion

        #region Sunglass Properties
        public string SGGender { get; set; }
        public string SGType { get; set; }
        public string SGFrameColor { get; set; }
        public string SGLenseColor { get; set; }
        public string SGFeatures { get; set; }
        public string SGSize { get; set; }
        public string SGMaterial { get; set; }
        public string SGStyle { get; set; }
        public string SGFaceShap { get; set; }
        #endregion

        #region Extra Properties
        public IFormFile File { get; set; }
        #endregion
    }
}
