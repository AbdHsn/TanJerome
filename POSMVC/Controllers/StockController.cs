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
using POSMVC.Models.PageModels.StockVM;
using X.PagedList;

namespace POSMVC.Controllers
{
    public class StockController : Controller
    {

        #region Global Variables
        private readonly EyePosDBContext _context;
        private readonly IMapper _mapper;
        private readonly CommonFunctions _cmnFunction;
        private readonly CommonBusinessLogics _cmnBusinessFunction;
        private readonly IHostingEnvironment _he;
        #endregion

        #region Constructor
        public StockController(
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
        public async Task<IActionResult> Stock(int? page, int? ddlId)
        {
            var pageNumber = page ?? 1;
            int pageRowSize = 10;
            int productType = ddlId ?? 0;

            var products = new List<ListStockVM>();

            if (productType == 0)
            {
                var getProducts = from s in _context.Stock
                                  join p in _context.Products on s.ProductId equals p.Id
                                  join pt in _context.ProductType on p.ProductTypeId equals pt.Id
                                  select new ListStockVM
                                  {
                                      Stock = s,
                                      Products = p,
                                      ProductType = pt
                                  };
                products = await getProducts.ToListAsync();
            }

            var result = products.ToPagedList(pageNumber, pageRowSize);
            return View("Stock", result);
        }

        public async Task<IActionResult> StockTrace(int? page, long productId = 0)
        {
            var pageNumber = page ?? 1;
            int pageRowSize = 10;

            var products = new List<ListStockTraceVM>();
            if (productId == 0)
            {
                var getProducts = from st in _context.StockTrace
                                  join p in _context.Products on st.ProductId equals p.Id
                                  select new ListStockTraceVM
                                  {
                                      StockTrace = st,
                                      Products = p
                                  };
                products = await getProducts.ToListAsync();
            }
            else {
                var getProducts = from st in _context.StockTrace
                                  where st.ProductId == productId
                                  join p in _context.Products on st.ProductId equals p.Id
                                  select new ListStockTraceVM
                                  {
                                      StockTrace = st,
                                      Products = p
                                  };
                products = await getProducts.ToListAsync();
            }

            var result = products.ToPagedList(pageNumber, pageRowSize);
            ViewData["productId"] = productId;

            return View("StockTrace", result);
        }


        [HttpGet, ActionName("CreateStockAdjustment")]
        public async Task<IActionResult> CreateStockAdjustment()
        {
            ViewData["Product"] = new SelectList(await _context.Products.ToListAsync(), "Id", "ProductCode");
            return PartialView("_CreateStockAdjustment");
        }
        #endregion

        #region PurchaseItems PostMethods

        [HttpPost, ActionName("CreateStockAdjustment")]
        public async Task<JsonResult> CreateStockAdjustment(StockAdjustment model)
        {
            var result = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    var getLastAdjustmentNo = _context.StockAdjustment.OrderByDescending(pu => pu.EntryDate).FirstOrDefault();
                    if (getLastAdjustmentNo != null)
                    {
                        int creatAdjustmentNo = Convert.ToInt32(getLastAdjustmentNo.AdjustmentNo.Substring(10)) + 1;
                        model.AdjustmentNo = "ADJ-" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + creatAdjustmentNo.ToString().PadLeft(10, '0');
                    }
                    else
                    {
                        model.AdjustmentNo = "ADJ-" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + 1.ToString().PadLeft(10, '0');
                    }

                    //1. Check Stock is exist or not for particular product, if Yes "Update Stock" Else "Create Stock"
                    var isStockExist = _context.Stock.Where(s => s.ProductId == model.ProductId).FirstOrDefault();
                    if (isStockExist == null)
                    {
                        return result = Json(new { success = true, message = model.AdjustmentNo + " successfully created.", redirectUrl = @"/Stock/Stock" });
                    }

                    isStockExist.LastQuantity = isStockExist.AvailableQuantity;
                    isStockExist.AvailableQuantity += model.Quantity;
                    isStockExist.LastUpdate = DateTime.UtcNow;

                    _context.Stock.Update(isStockExist);
                    _context.SaveChanges();

                    _cmnBusinessFunction.CreateStockTrace(new CreateStockTraceBM()
                    {
                        NewQuantity = Convert.ToInt32(model.Quantity),
                        ProductId = Convert.ToInt64(model.ProductId),
                        ReferenecId = model.AdjustmentNo,
                        TableReference = "Stock Adjustment",
                        Note = "Generated From Stock/CreateStockAdjustment"
                    });


                    model.EntryDate = DateTime.UtcNow;
                    _context.StockAdjustment.Add(model);
                    _context.SaveChanges();

                    return result = Json(new { success = true, message = model.AdjustmentNo + " successfully created.", redirectUrl = @"/Stock/Stock" });
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


            var products = new List<ListStockVM>();


            var getProducts = from s in _context.Stock
                              join p in _context.Products on s.ProductId equals p.Id
                              join pt in _context.ProductType on p.ProductTypeId equals pt.Id
                              select new ListStockVM
                              {
                                  Stock = s,
                                  Products = p,
                                  ProductType = pt
                              };

            products = await getProducts.ToListAsync();

            ViewBag.SearchValue = purchaseNo;
            var result = products.ToPagedList(pageNumber, pageRowSize);

            return View("PurchaseItems/SearchPurchaseItem", result);
        }
        #endregion

    }
}
