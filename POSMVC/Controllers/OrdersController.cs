using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using CommonLogics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using POSMVC.CommonBusinessFunctions;
using POSMVC.CommonBusinessFunctions.BusinessModels;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.ItemVM;
using POSMVC.Models.PageModels.OrdersVM;
using POSMVC.Models.PageModels.UsersVM;
using X.PagedList;

namespace POSMVC.Controllers
{
    public class OrdersController : Controller
    {

        #region Global Variables
        private readonly EyePosDBContext _context;
        private readonly IMapper _mapper;
        private readonly CommonFunctions _cmnFunction;
        private readonly CommonBusinessLogics _cmnBusinessFunction;
        private readonly IHostingEnvironment _he;
        #endregion

        #region Constructor
        public OrdersController(
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

        #region CLOrder GetMethods
        [HttpGet, ActionName("CLOrder")]
        public async Task<IActionResult> CreateCLOrder()
        {
            var ddlProduct = from s in _context.Stock
                             join p in _context.Products on s.ProductId equals p.Id
                             select new { ProductCode = p.ProductCode + "( Available Qty: "+ s.AvailableQuantity +")", Id = p.Id };
            ViewData["Product"] = new SelectList(ddlProduct, "Id", "ProductCode");

            return View("CreateCLOrder", new CreateCLOrderVM());
        }

        [HttpPost, ActionName("CreateCLOrder")]
        public async Task<JsonResult> CreateCLOrder(CreateCLOrderVM model)
        {
            var result = (dynamic)null;
            try
            {

                if (model.ContactLense != null && model.Users != null)
                {

                    using (TransactionScope transaction = new TransactionScope()) {

                        Orders lastOrder = _context.Orders.OrderByDescending(o => o.OrderPlaceDate).FirstOrDefault();
                        //Order No generating...
                        if (lastOrder != null)
                        {
                            int newOrderNo = Convert.ToInt32(lastOrder.OrderNo.Substring(10)) + 1;
                            model.Order.OrderNo = _cmnBusinessFunction.GenerateNumberWithPrefix("ORD-", newOrderNo.ToString());
                        }
                        else
                        {
                            model.Order.OrderNo = _cmnBusinessFunction.GenerateNumberWithPrefix("ORD-", 1.ToString());
                        }
                        //Importing Prescription record...
                        if (model.ContactLense.Id > 0)
                        {
                            //Update if record exist
                            var preCL = _context.ContactLenseRx.Find(model.ContactLense.Id);

                            model.ContactLense.UserId = preCL.UserId;
                            model.ContactLense.CreatedDate = preCL.CreatedDate;
                            model.ContactLense.UpdatedDate = DateTime.UtcNow;
                            model.ContactLense.CheckedBy = 0;
                            model.ContactLense.CheckedDate = null;

                            _context.Entry(preCL).CurrentValues.SetValues(model.ContactLense);
                            _context.SaveChanges();
                        }
                        else
                        {
                            //Create new if not record exist
                            model.ContactLense.UserId = model.Users.Id;
                            model.ContactLense.CreatedDate = DateTime.UtcNow;
                            _context.ContactLenseRx.Add(model.ContactLense);
                            _context.SaveChanges();
                        }
                        //Importing Order Master record...
                        model.Order.UserId = model.Users.Id;
                        model.Order.GrandTotal = model.ListOrderDetails.Sum(s => s.Total);
                        model.Order.BillingAddress = model.Order.BillingAddress;
                        model.Order.OrderPlaceDate = DateTime.Now;
                        model.Order.CollectionDate = model.Order.CollectionDate;
                        model.Order.OrderStatus = "Received";
                        _context.Orders.Add(model.Order);
                        _context.SaveChanges();
                        //Importing Order Child record...
                        foreach (var item in model.ListOrderDetails)
                        {
                            //Checking stock is available or not, if not return back.
                            var isStockAvailable = from s in _context.Stock
                                                   where s.ProductId == item.ProductId
                                                   join p in _context.Products on s.ProductId equals p.Id
                                                   select new { s, p };

                            var currentStock = isStockAvailable.FirstOrDefault();
                            if (item.Quantity > currentStock.s.AvailableQuantity)
                            {
                                return result = Json(new { success = false, message = " Order can't proceed, "+ currentStock.p.ProductCode+ " out of stock.", redirectUrl = "" });
                            }

                            item.OrderId = model.Order.Id;
                            //item.CollectionDate = DateTime.Now;
                            _context.OrderDetails.Add(item);
                            _context.SaveChanges();

                            //Updating Stock of current item
                            currentStock.s.LastQuantity = currentStock.s.AvailableQuantity;
                            currentStock.s.AvailableQuantity -= item.Quantity;
                            currentStock.s.LastUpdate = DateTime.UtcNow;

                            _context.Stock.Update(currentStock.s);
                            _context.SaveChanges();
                            //Creating stock trace
                            _cmnBusinessFunction.CreateStockTrace(new CreateStockTraceBM()
                            {
                                NewQuantity = -Convert.ToInt32(item.Quantity),
                                ProductId = Convert.ToInt64(item.ProductId),
                                ReferenecId = model.Order.OrderNo,
                                TableReference = "Sales Order",
                                Note = "Generated From Orders/CreateCLOrder"
                            });
                        }

                        transaction.Complete();
                        return result = Json(new { success = true, message = " Order successfully placed.", redirectUrl = @"/Orders/Payment" });
                    }
                }
                else
                    return result = Json(new { success = false, message = "Failed to place order.", redirectUrl = "" });
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }

        [Produces("application/json")]
        [HttpGet, ActionName("GetLastRX")]
        public async Task<IActionResult> GetLastRX(string jsonData)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<Users>(jsonData);
                var result = await _context.ContactLenseRx.Where(u => u.UserId == user.Id).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [Produces("application/json")]
        [HttpGet, ActionName("GetProduct")]
        public async Task<IActionResult> GetProduct(string jsonData)
        {
            try
            {
                var product = JsonConvert.DeserializeObject<Products>(jsonData);
                var result = from s in _context.Stock
                             where s.ProductId == product.Id
                             join p in _context.Products on s.ProductId equals p.Id
                             select new { stock = s, product = p };
               // var result = await _context.Products.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
                return Ok(await result.FirstOrDefaultAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion

        #region Customer GetMethods
        [HttpGet, ActionName("CreateCustomer")]
        public async Task<IActionResult> Create()
        {
            var customerTypes = new List<int> { 4, 5, 6, 7 };

            ViewData["UserTypeId"] = new SelectList(await _context.UserType.Where(u => customerTypes.Contains(u.Id)).ToListAsync(), "Id", "TypeName");
            return PartialView("_CreateCustomer", new CreateCustomerVM());
        }
        #endregion

        #region Customer PostMethods
        [HttpPost, ActionName("CreateCustomer")]
        public async Task<JsonResult> CreateCustomer(CreateCustomerVM user)
        {
            var result = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    user.Users.CreateDate = DateTime.UtcNow;
                    user.Users.UserName = user.Users.Email;
                    _context.Users.Add(user.Users);
                    await _context.SaveChangesAsync();

                    user.PersonalDetail.UserId = user.Users.Id;
                    _context.PersonalDetail.Add(user.PersonalDetail);
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
                    return result = Json(new { success = true, message = user.PersonalDetail.Name + " successfully created.", redirectUrl = @"/Orders/CLOrder" });
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
                        model.PurchaseNo = "PUR-" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + creatPurchaseNo.ToString().PadLeft(10, '0');
                    }
                    else
                    {
                        model.PurchaseNo = "PUR-" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + 1.ToString().PadLeft(10, '0');
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

        #region CustomerSearchMethods

        [Produces("application/json")]
        [HttpGet, ActionName("CustomerSearch")]
        public async Task<IActionResult> CustomerSearch()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var result = await _context.PersonalDetail.Where(p => p.MobileNo.Contains(term)).Select(p => p.MobileNo + " (" + p.Name + ")").ToListAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [HttpGet, ActionName("CustomerSearchResult")]
        public async Task<IActionResult> CustomerSearchResult(string jsonData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<String>(jsonData);

                var mobileNo = data.Split(" (").FirstOrDefault();

                var customerTypes = new List<int> { 4, 5, 6, 7 };
                var personalD = await _context.PersonalDetail.Where(p => p.MobileNo == mobileNo).FirstOrDefaultAsync();
                var userData = await _context.Users.Where(u => u.Id == personalD.UserId).FirstOrDefaultAsync();
                var userType = await _context.UserType.Where(ut => ut.Id == userData.UserTypeId).FirstOrDefaultAsync();

                var cl = new CreateCLOrderVM()
                {
                    PersonalDetail = personalD,
                    Users = userData,
                    UserType = userType
                };
                var result = cl;
                return Ok(result);
            }
            catch(Exception ex)
            {
                string err = ex.ToString();
                return BadRequest();
            }
        }

        #endregion

    }
}
