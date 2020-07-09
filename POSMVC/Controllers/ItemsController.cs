using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonLogics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POSMVC.CommonBusinessFunctions;
using POSMVC.CommonBusinessFunctions.BusinessModels;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.ItemVM;
using POSMVC.Models.PageModels.UsersVM;
using X.PagedList;

namespace POSMVC.Controllers
{
    public class ItemsController : Controller
    {

        #region Global Variables
        private readonly EyePosDBContext _context;
        private readonly IMapper _mapper;
        private readonly CommonFunctions _cmnFunction;
        private readonly CommonBusinessLogics _cmnBusinessFunction;
        private readonly IHostingEnvironment _he;
        #endregion

        #region Constructor
        public ItemsController(
               EyePosDBContext context,
               IMapper mapper,
               CommonFunctions cmnFunction,
               CommonBusinessLogics cmnBusinessFunction,
               IHostingEnvironment he
        )
        {
            _context = context;
            _mapper = mapper;
            _cmnFunction = cmnFunction;
            _cmnBusinessFunction = cmnBusinessFunction;
            _he = he;
        }
        #endregion

        #region PurchaseItems GetMethods
        public async Task<IActionResult> PurchaseItems(int? page, int? ddlId)
        {
            var pageNumber = page ?? 1;
            int pageRowSize = 10;
            int productType = ddlId ?? 0;

            var purchaseItems = new List<ListPurchaseVM>();

            if (productType == 0)
            {
                var getPurchase = from pu in _context.Purchase
                                  orderby pu.EntryDate descending
                                  join p in _context.Products on pu.ProductId equals p.Id
                                  join pt in _context.ProductType on p.ProductTypeId equals pt.Id
                                  join mf in _context.Manufacturer on p.ManufacturerId equals mf.Id
                                  join br in _context.Brand on p.BrandId equals br.Id
                                  select new ListPurchaseVM
                                  {
                                      Purchase = pu,
                                      Products = p,
                                      ProductType = pt,
                                      Brand = br,
                                      Manufacturer = mf
                                  };
                purchaseItems = await getPurchase.ToListAsync();
            }

            var result = purchaseItems.ToPagedList(pageNumber, pageRowSize);
            return View("PurchaseItems/PurchaseItems", result);
        }

        [HttpGet, ActionName("CreatePurchaseItem")]
        public async Task<IActionResult> CreatePurchaseItem()
        {
            ViewData["Product"] = new SelectList(await _context.Products.ToListAsync(), "Id", "ProductCode");
            ViewData["Manufacturer"] = new SelectList(await _context.Manufacturer.ToListAsync(), "Id", "ManufacturerName");

            return PartialView("PurchaseItems/_CreatePurchaseItems", new Purchase());
        }
        #endregion

        #region Items GetMethods
        public async Task<IActionResult> Items(int? page, int? ddlId)
        {
            var pageNumber = page ?? 1;
            int pageRowSize = 10;
            int productType = ddlId ?? 0;

            var products = new List<ListProductVM>();

            if (productType == 0)
            {
                var getProducts = from p in _context.Products
                                  join pt in _context.ProductType on p.ProductTypeId equals pt.Id
                                  join br in _context.Brand on p.BrandId equals br.Id
                                  join mf in _context.Manufacturer on p.ManufacturerId equals mf.Id
                                  select new ListProductVM
                                  {
                                      Products = p,
                                      ProductType = pt,
                                      Brand = br,
                                      Manufacturer = mf
                                  };
                products = await getProducts.ToListAsync();
            }
            else
            {
                var getProducts = from p in _context.Products
                                  where p.ProductTypeId == productType
                                  join pt in _context.ProductType on p.ProductTypeId equals pt.Id
                                  join br in _context.Brand on p.BrandId equals br.Id
                                  join mf in _context.Manufacturer on p.ManufacturerId equals mf.Id
                                  select new ListProductVM
                                  {
                                      Products = p,
                                      ProductType = pt,
                                      Brand = br,
                                      Manufacturer = mf
                                  };

                products = getProducts.ToList();
            }

            ViewData["addProductType"] = new SelectList(_context.ProductType, "Id", "TypeName");
            ViewData["addManufacturer"] = new SelectList(_context.Manufacturer, "Id", "ManufacturerName");
            ViewData["addBrand"] = new SelectList(_context.Brand, "Id", "Name");

            ViewData["ProductType"] = new SelectList(_context.ProductType, "Id", "TypeName", productType);
            ViewData["SelectedProductTypeName"] = productType == 0 ? "All" : _context.ProductType.Find(productType).TypeName;

            var result = products.ToPagedList(pageNumber, pageRowSize);
            return View(result);
        }

        [HttpGet, ActionName("CreateSingleItem")]
        public async Task<IActionResult> CreateItem()
        {
            ViewData["ProductType"] = new SelectList(await _context.ProductType.ToListAsync(), "Id", "TypeName");
            ViewData["Brand"] = new SelectList(await _context.Brand.ToListAsync(), "Id", "Name");
            ViewData["Manufacturer"] = new SelectList(await _context.Manufacturer.ToListAsync(), "Id", "ManufacturerName");

            return PartialView("_CreateItem", new Products());
        }

        [HttpGet, ActionName("EditSingleItem")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id != 0)
            {
                var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product != null)
                {
                    ViewData["ProductType"] = new SelectList(await _context.ProductType.ToListAsync(), "Id", "TypeName", product.ProductTypeId);
                    ViewData["Brand"] = new SelectList(await _context.Brand.ToListAsync(), "Id", "Name", product.BrandId);
                    ViewData["Manufacturer"] = new SelectList(await _context.Manufacturer.ToListAsync(), "Id", "ManufacturerName", product.ManufacturerId);

                    return PartialView("_UpdateItem", product);
                }
                else
                    return PartialView("_UpdateItem", new Products());
            }
            else
            {
                ViewData["UserTypeId"] = new SelectList(_context.UserType, "Id", "TypeName");
                return PartialView("_UpdateCustomer", new EditUserVM());
            }
        }
        #endregion

        #region PurchaseItems PostMethods

        [HttpPost, ActionName("CreatePurchaseItem")]
        public async Task<JsonResult> CreatePurchaseItem(Purchase model)
        {
            var result = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    var getLastPurchaseNo = _context.Purchase.OrderByDescending(pu => pu.EntryDate).FirstOrDefault();
                    if (getLastPurchaseNo != null)
                    {
                        int creatPurchaseNo = Convert.ToInt32(getLastPurchaseNo.PurchaseNo.Substring(10)) + 1;
                       // model.PurchaseNo = "PUR-" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + creatPurchaseNo.ToString().PadLeft(10, '0');
                        model.PurchaseNo = _cmnBusinessFunction.GenerateNumberWithPrefix("PUR-", creatPurchaseNo.ToString());
                    }
                    else
                    {
                        //model.PurchaseNo = "PUR-" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + 1.ToString().PadLeft(10, '0');
                        model.PurchaseNo = _cmnBusinessFunction.GenerateNumberWithPrefix("PUR-", 1.ToString());

                    }

                    var isStockExist = _context.Stock.Where(s => s.ProductId == model.ProductId).FirstOrDefault();
                    if (isStockExist != null)
                    {
                        isStockExist.LastQuantity = isStockExist.AvailableQuantity;
                        isStockExist.AvailableQuantity += model.Quantity;
                        isStockExist.LastUpdate = DateTime.UtcNow;

                        _context.Stock.Update(isStockExist);
                        _context.SaveChanges();

                        _cmnBusinessFunction.CreateStockTrace(new CreateStockTraceBM()
                        {
                            NewQuantity = Convert.ToInt32(model.Quantity),
                            ProductId = Convert.ToInt64(model.ProductId),
                            ReferenecId = model.PurchaseNo,
                            TableReference = "Purchase",
                            Note = "Generated From Items/CreatePurchaseItem"
                        });
                    }
                    else
                    {
                        var newStock = new Stock()
                        {
                            ProductId = model.ProductId,
                            AvailableQuantity = model.Quantity,
                            LastQuantity = 0,
                            CreatedDate = DateTime.UtcNow
                        };
                        _context.Stock.Add(newStock);
                        await _context.SaveChangesAsync();

                        _cmnBusinessFunction.CreateStockTrace(new CreateStockTraceBM()
                        {
                            NewQuantity = Convert.ToInt32(model.Quantity),
                            ProductId = Convert.ToInt64(model.ProductId),
                            ReferenecId = model.PurchaseNo,
                            TableReference = "Purchase",
                            Note = "Generated From Items/CreatePurchaseItem"
                        });
                    }

                    model.EntryDate = DateTime.UtcNow;
                    _context.Purchase.Add(model);
                    _context.SaveChanges();

                    return result = Json(new { success = true, message = model.PurchaseNo + " successfully created.", redirectUrl = @"/Items/PurchaseItems" });
                }
                else
                    return result = Json(new { success = false, message = "Data is not valid.", redirectUrl = "" });

            }
            catch (Exception ex)
            {
                string err = @"Exception occured at Items/CreateSingleItem: " + ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }

        // [HttpPost, ActionName("ImportFromExcel")]
        //public async Task<JsonResult> ImportFromExcel( IFormFile file)
        //{
        //    var result = (dynamic)null;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            await Task.Run(() => {

        //            });
        //        }
        //        else
        //            return result = Json(new { success = false, message = "Data is not valid.", redirectUrl = "" });

        //    }
        //    catch (Exception ex)
        //    {
        //        string err = @"Exception occured at Users/Create: " + ex.ToString();
        //        return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
        //    }
        //}
        #endregion

        #region Items PostMethods

        [HttpPost, ActionName("CreateSingleItem")]
        public async Task<JsonResult> Create(Products model)
        {
            var result = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = System.DateTime.UtcNow;
                    model.IsActive = true;
                    _context.Products.Add(model);
                    await _context.SaveChangesAsync();

                    ////Image insertion Code
                    //if (user.Users.Id > 0)
                    //{
                    //    if (user.file != null)
                    //    {
                    //        string extension = Path.GetExtension(user.file.FileName);
                    //        string smallImage = "StaticFiles/Users/SmallImage/";
                    //        string bigImage = "StaticFiles/Users/BigImage/";

                    //        if (_cmnFunction.SaveImage(user.file, user.Users.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
                    //        {
                    //            user.Users.SmallImage = smallImage + user.Users.Id.ToString() + extension;
                    //        }

                    //        if (_cmnFunction.SaveImage(user.file, user.Users.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
                    //        {
                    //            user.Users.BigImage = bigImage + user.Users.Id.ToString() + extension;
                    //        }

                    //        _context.Entry(user.Users).State = EntityState.Modified;
                    //        await _context.SaveChangesAsync();
                    //    }
                    //}
                    ////Image insertion Code
                    ///
                    return result = Json(new { success = true, message = model.ProductCode + " successfully created.", redirectUrl = @"/Items/Items" });
                }
                else
                    return result = Json(new { success = false, message = "Data is not valid.", redirectUrl = "" });

            }
            catch (Exception ex)
            {
                string err = @"Exception occured at Items/CreateSingleItem: " + ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }

        [HttpPost, ActionName("EditSingleItem")]
        public async Task<JsonResult> Edit(Products model)
        {
            var result = (dynamic)null;

            try
            {
                if (model.Id <= 0)
                {
                    return result = Json(new { success = false, message = " Record is not found", redirectUrl = @"/Items/Items" });
                }

                var product = await _context.Products.Where(pd => pd.Id == model.Id).FirstOrDefaultAsync();
                product.ProductTypeId = model.ProductTypeId;
                product.ProductCode = model.ProductCode;
                product.BrandId = model.BrandId;
                product.ManufacturerId = model.ManufacturerId;
                product.Type = model.Type;
                product.Bc = model.Bc;
                product.Diameter = model.Diameter;
                product.ColorCode = model.ColorCode;
                product.Size = model.Size;
                product.SellingPrice = model.SellingPrice;
                product.CostPrice = model.CostPrice;
                product.UpdateDate = DateTime.UtcNow;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return result = Json(new { success = true, message = "Record successfully updated", redirectUrl = @"/Items/Items" });
            }
            catch (Exception ex)
            {
                string err = @"Exception occured at Items/EditSingleItem " + ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }


        [HttpPost, ActionName("DeleteSingleItem")]
        public async Task<JsonResult> Delete(Products model)
        {
            var result = (dynamic)null;
            try
            {
                var product = await _context.Products.Where(c => c.Id == model.Id).FirstOrDefaultAsync();

                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();

                    return result = Json(new { success = true, message = " Record successfully deleted.", redirectUrl = @"/Items/Items" });
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


        [HttpPost, ActionName("ImportFromExcel")]
        //public async Task<JsonResult> ImportFromExcel( IFormFile file)
        //{
        //    var result = (dynamic)null;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            await Task.Run(() => {

        //            });
        //        }
        //        else
        //            return result = Json(new { success = false, message = "Data is not valid.", redirectUrl = "" });

        //    }
        //    catch (Exception ex)
        //    {
        //        string err = @"Exception occured at Users/Create: " + ex.ToString();
        //        return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
        //    }
        //}
        #endregion

        #region RemoteValidation
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public JsonResult IsEmailExist(CreateUserVM user)
        {
            var email = _context.Users.Where(u => u.Email == user.Users.Email).SingleOrDefault();
            if (email == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"\"{user.Users.Email}\" is already used.");
            }
        }
        #endregion RemoteValidation

        #region PurchaseItem Search Methods
        [Produces("application/json")]
        [HttpGet, ActionName("ItemPurchaseSearch")]
        public async Task<IActionResult> ItemPurchaseSearch()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var result = await _context.Purchase.Where(p => p.PurchaseNo.Contains(term)).Select(p => p.PurchaseNo).ToListAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet, ActionName("SearchPurchaseResult")]
        public async Task<IActionResult> SearchPurchaseResult(string purchaseNo)
        {
            var pageNumber = 1;
            int pageRowSize = 10;


            var purchaseItem = new List<ListPurchaseVM>();

            var getPurchase = from pu in _context.Purchase
                              where pu.PurchaseNo == purchaseNo
                              orderby pu.EntryDate descending
                              join p in _context.Products on pu.ProductId equals p.Id
                              join pt in _context.ProductType on p.ProductTypeId equals pt.Id
                              join mf in _context.Manufacturer on p.ManufacturerId equals mf.Id
                              join br in _context.Brand on p.BrandId equals br.Id
                              select new ListPurchaseVM
                              {
                                  Purchase = pu,
                                  Products = p,
                                  ProductType = pt,
                                  Brand = br,
                                  Manufacturer = mf
                              };
            purchaseItem = await getPurchase.ToListAsync();

            ViewBag.SearchValue = purchaseNo;
            var result = purchaseItem.ToPagedList(pageNumber, pageRowSize);

            return View("PurchaseItems/SearchPurchaseItem", result);
        }
        #endregion

        #region Item Search Methods
        [Produces("application/json")]
        [HttpGet, ActionName("ItemSearch")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var result = await _context.Products.Where(p => p.ProductCode.Contains(term)).Select(p => p.ProductCode).ToListAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet, ActionName("SearchResult")]
        public async Task<IActionResult> SearchResult(string productCode)
        {
            var pageNumber = 1;
            int pageRowSize = 10;
            int productType = 0;

            var products = new List<ListProductVM>();
            var getProducts = from p in _context.Products
                              where p.ProductCode == productCode
                              join pt in _context.ProductType on p.ProductTypeId equals pt.Id
                              join br in _context.Brand on p.BrandId equals br.Id
                              join mf in _context.Manufacturer on p.ManufacturerId equals mf.Id
                              select new ListProductVM
                              {
                                  Products = p,
                                  ProductType = pt,
                                  Brand = br,
                                  Manufacturer = mf
                              };
            products = await getProducts.ToListAsync();

            ViewData["ProductType"] = new SelectList(_context.ProductType, "Id", "TypeName", productType);
            ViewData["SelectedProductTypeName"] = productType == 0 ? "All" : _context.ProductType.Find(productType).TypeName;
            ViewBag.SearchValue = productCode;
            var result = products.ToPagedList(pageNumber, pageRowSize);
            return View("SearchItem", result);
        }
        #endregion

    }
}
