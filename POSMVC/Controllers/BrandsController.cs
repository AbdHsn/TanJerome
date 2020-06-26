using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonLogics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.BrandsVM;
using X.PagedList;

namespace POSMVC.Controllers
{
    public class BrandsController : Controller
    {
        #region Global Variables
        private readonly EyePosDBContext _context;
        private readonly IMapper _mapper;
        private readonly CommonFunctions _cmnFunction;
        private readonly IHostingEnvironment _he;
        #endregion

        #region Constructor
        public BrandsController(
               EyePosDBContext context,
               IMapper mapper,
               CommonFunctions cmnFunction,
               IHostingEnvironment he
        )
        {
            _context = context;
            _mapper = mapper;
            _cmnFunction = cmnFunction;
            _he = he;
        }
        #endregion

        #region GetMethods
        public async Task<IActionResult> Brands(int? page)
        {
            var pageNumber = page ?? 1;
            int pageRowSize = 10;

            var brands = from b in _context.Brand
                        select new ListBrandVM { Brand = b };

            var result = brands.ToPagedList(pageNumber, pageRowSize);

            return View(result);
        }

        [HttpGet, ActionName("CreateBrand")]
        public async Task<IActionResult> Create()
        {
            return PartialView("_CreateBrand", new CreateBrandVM());
        }

        [HttpGet, ActionName("EditBrand")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id != 0)
            {
                var exBrand = await _context.Brand.Where(b => b.Id == id).FirstOrDefaultAsync();
                var returnModel = new EditBrandVM() { Brand = exBrand };
                return PartialView("_UpdateBrand", returnModel);
            }
            else
            {
                return PartialView("_UpdateBrand", new EditBrandVM());
            }
        }
        #endregion

        //#region PostMethods

        [HttpPost, ActionName("CreateBrand")]
        public async Task<JsonResult> Create(CreateBrandVM model)
        {
            var result = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    model.Brand.CreateDate = DateTime.UtcNow;
                    _context.Brand.Add(model.Brand);
                    await _context.SaveChangesAsync();

                    if (model.Brand.Id > 0)
                    {
                        if (model.file != null)
                        {
                            string extension = Path.GetExtension(model.file.FileName);
                            string smallImage = "StaticFiles/Brands/SmallImage/";
                            string bigImage = "StaticFiles/Brands/BigImage/";

                            if (_cmnFunction.SaveImage(model.file, model.Brand.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
                            {
                                model.Brand.SmallImage = smallImage + model.Brand.Id.ToString() + extension;
                            }

                            if (_cmnFunction.SaveImage(model.file, model.Brand.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
                            {
                                model.Brand.BigImage = bigImage + model.Brand.Id.ToString() + extension;
                            }

                            _context.Entry(model.Brand).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                    }
                    return result = Json(new { success = true, message = "Brand uccessfully created.", redirectUrl = @"/Brands/Brands" });
                }
                else
                    return result = Json(new { success = false, message = "Data is not valid.", redirectUrl = "" });

            }
            catch (Exception ex)
            {
                string err = @"Exception occured at Users/Create: " + ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }

        [HttpPost, ActionName("EditBrand")]
        public async Task<JsonResult> Edit(EditBrandVM model)
        {
            var result = (dynamic)null;

            try
            {
                if (model.Brand.Id <= 0)
                {
                    return result = Json(new { success = false, message = " Record is not found", redirectUrl = @"/Brands/Brands" });
                }

                var exBrand = await _context.Brand.FindAsync(model.Brand.Id);
                exBrand.Name = model.Brand.Name;

                _context.Brand.Update(exBrand);
                await _context.SaveChangesAsync();

                if (model.file != null)
                {
                    //Delete previous physical image if exist
                    if (!string.IsNullOrEmpty(exBrand.SmallImage))
                    {
                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, exBrand.SmallImage));
                    }
                    if (!string.IsNullOrEmpty(exBrand.BigImage))
                    {
                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, exBrand.BigImage));
                    }

                    string smallImage = "StaticFiles/Brands/SmallImage/";
                    string bigImage = "StaticFiles/Brands/BigImage/";
                    string extension = Path.GetExtension(model.file.FileName);

                    //Place updated image into server
                    if (_cmnFunction.SaveImage(model.file, model.Brand.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
                    {
                        exBrand.SmallImage = smallImage + model.Brand.Id.ToString() + extension;
                    }

                    if (_cmnFunction.SaveImage(model.file, model.Brand.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
                    {
                        exBrand.BigImage = bigImage + model.Brand.Id.ToString() + extension;
                    }
                }

                _context.Entry(exBrand).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return result = Json(new { success = true, message = "Record successfully updated", redirectUrl = @"/Brands/Brands" });
            }
            catch (Exception ex)
            {
                string err = @"Exception occured at Brands/EditBrand " + ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }

        [HttpPost, ActionName("DeleteBrand")]
        public async Task<JsonResult> Delete(Brand model)
        {
            var result = (dynamic)null;
            try
            {
                var brand = await _context.Brand.Where(c => c.Id == model.Id ).FirstOrDefaultAsync();

                if (brand != null)
                {
                    //Delete  physical image file
                    if (!string.IsNullOrEmpty(brand.BigImage))
                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, brand.BigImage));

                    if (!string.IsNullOrEmpty(brand.SmallImage))
                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, brand.SmallImage));

                    _context.Brand.Remove(brand);
                    await _context.SaveChangesAsync();

                    return result = Json(new { success = true, message = " Record successfully deleted.", redirectUrl = @"/Brands/Brands" });
                }
                else
                    return result = Json(new { success = false, message = " Record is not found.", redirectUrl = "" });
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }

        //#endregion

        //#region RemoteValidation
        //[AcceptVerbs("Get", "Post")]
        //[AllowAnonymous]
        //public JsonResult IsEmailExist(CreateUserVM user)
        //{
        //    var email = _context.Users.Where(u => u.Email == user.Users.Email).SingleOrDefault();
        //    if (email == null)
        //    {
        //        return Json(true);
        //    }
        //    else
        //    {
        //        return Json($"\"{user.Users.Email}\" is already used.");
        //    }
        //}
        //#endregion RemoteValidation

        #region SearchMethods
        [Produces("application/json")]
        [HttpGet, ActionName("BrandSearch")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var brandNames = await _context.Brand.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToListAsync();
                return Ok(brandNames);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet, ActionName("SearchResult")]
        public async Task<IActionResult> SearchPeople(string brand)
        {
            var pageNumber = 1;
            int pageRowSize = 10;

            var brands = from b in _context.Brand where b.Name == brand 
                         select new ListBrandVM { Brand = b };

            var result = brands.ToPagedList(pageNumber, pageRowSize);
            ViewData["SearchValue"] = brand;

            return View("SearchBrand", result);
        }
        #endregion
    }
}
