using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper.Configuration.Conventions;
using CommonLogics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit.IO.Filters;
using Newtonsoft.Json;
using POSMVC.CommonBusinessFunctions;
using POSMVC.CommonBusinessFunctions.BusinessModels;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.OrdersVM;
using POSMVC.Models.PageModels.OrdersVM.CCOrderInvoice;
using POSMVC.Models.PageModels.OrdersVM.CLOrderInvoice;
using POSMVC.Models.PageModels.OrdersVM.SpecOrderInvoice;
using POSMVC.Models.PageModels.PaymentsVM;
using POSMVC.Models.SharedModels;
using X.PagedList;
using ZXing.QrCode.Internal;

namespace POSMVC.Controllers
{
    public class OrdersController : Controller
    {

        #region Global Variables
        private readonly EyePosDBContext _context;
        private readonly CommonFunctions _cmnFunction;
        private readonly CommonBusinessLogics _cmnBusinessFunction;
        private readonly IHostingEnvironment _he;
        #endregion

        #region Constructor
        public OrdersController(
               EyePosDBContext context,
               CommonFunctions cmnFunction,
               CommonBusinessLogics cmnBusinessFunction,
               IHostingEnvironment he
        )
        {
            _context = context;
            _cmnFunction = cmnFunction;
            _cmnBusinessFunction = cmnBusinessFunction;
            _he = he;
        }
        #endregion

        #region Orders
        public async Task<IActionResult> Orders(int? page, string orderStatus = null)
        {
            var pageNumber = page ?? 1;
            int pageRowSize = 3;
            
            var fetchOrders = new List<OrdersVM>();
            if (string.IsNullOrEmpty(orderStatus) || orderStatus == "All")
            {
                var fetchOrder = from o in _context.Orders
                                 join u in _context.Users on o.UserId equals u.Id
                                 join ut in _context.UserType on u.UserTypeId equals ut.Id
                                 join pd in _context.PersonalDetail on u.Id equals pd.UserId
                                 orderby o.OrderPlaceDate descending
                                 select new OrdersVM
                                 {
                                     Orders = o,
                                     Users = u,
                                     UserType = ut,
                                     PersonalDetail = pd
                                  };
                fetchOrders = fetchOrder.ToList();
            }
            else
            {
                var fetchOrder = from o in _context.Orders
                                  where o.OrderStatus == orderStatus
                                  join u in _context.Users on o.UserId equals u.Id
                                  join ut in _context.UserType on u.UserTypeId equals ut.Id
                                  join pd in _context.PersonalDetail on u.Id equals pd.UserId
                                  orderby o.OrderPlaceDate descending
                                  select new OrdersVM
                                  {
                                      Orders = o,
                                      Users = u,
                                      UserType = ut,
                                      PersonalDetail = pd
                                  };
                fetchOrders = fetchOrder.ToList();
            }

            var orders = new List<OrdersVM>();
            foreach (var item in fetchOrders)
            {
                var orderVm = new OrdersVM();
                orderVm.Orders = item.Orders;
                orderVm.Users = item.Users;
                orderVm.UserType = item.UserType;
                orderVm.PersonalDetail = item.PersonalDetail;

                //Fetch Payment data.
                var paidAmounts = _context.Payment.Where(p => p.InstrumentNo == item.Orders.OrderNo) == null ? 0 : (decimal)_context.Payment.Where(p => p.InstrumentNo == item.Orders.OrderNo).Sum(s => s.PaidAmount);
                orderVm.PaidAmount = paidAmounts;
                orderVm.DueAmount = (decimal)(item.Orders.GrandTotal - paidAmounts);

                if (paidAmounts == 0)
                {
                    orderVm.PaidStatus = "Not Paid";
                }                
                if (paidAmounts >= item.Orders.GrandTotal)
                {
                    orderVm.PaidStatus = "Full Paid";
                }               
                if (paidAmounts > 0 && paidAmounts < item.Orders.GrandTotal)
                {
                    orderVm.PaidStatus = "Partial Paid";
                }

                orders.Add(orderVm);
            }

            ViewData["ddlOrderStatus"] = new SelectList( 
                from DefaultValues.OrderStatus e in Enum.GetValues(typeof(DefaultValues.OrderStatus)) 
                select new { Id = (int)e, Name = e.ToString()}, "Id", "Name");

            ViewData["SelectedOrderStatus"] = string.IsNullOrEmpty(orderStatus) ? "All" : orderStatus;
            ViewData["PageNumber"] = pageNumber;
            
            var result = await orders.ToPagedListAsync(pageNumber, pageRowSize);

            return View(result);
        }
        public async Task<IActionResult> OrdersStatusModified(long orderId, string newOrderStatus,  int? page, string oldOrderStatus = null)
        {
            var fetchOrder = await _context.Orders.FindAsync(orderId);
            if (fetchOrder != null)
            {
                fetchOrder.OrderStatus = newOrderStatus;
                fetchOrder.LastUpdate = DateTime.Now.ToUniversalTime();
                _context.Orders.Update(fetchOrder);
                _context.SaveChanges();
            }

            return RedirectToAction("Orders", new { page, orderStatus = oldOrderStatus });
        }

        [HttpGet, ActionName("ViewTransactions")]
        public async Task<IActionResult> Transactions(long orderId)
        {
            var model = new Models.PageModels.OrdersVM.PaymentsVM();
            if (orderId > 0)
            {
                var order = await _context.Orders.FindAsync(orderId);
                var payments = from p in _context.Payment
                               where p.InstrumentNo == order.OrderNo
                               join pm in _context.PaymentMethods on p.PaymentMethodId equals pm.Id
                               select new paymentDetail
                               { 
                                    Payment = p,
                                    paymentMethods = pm
                               };

                    model = new Models.PageModels.OrdersVM.PaymentsVM() {
                    Orders = order,
                    ListPayments = payments.ToList(),
                    TotalPaidAmount = (decimal)payments.Sum(s => s.Payment.PaidAmount),
                   
                };
                model.DueAmount = (decimal)(order.GrandTotal - model.TotalPaidAmount);
            }
            return PartialView("_Transactions", model);
        }

        #endregion


        #region ContactLens Order GetMethods
        [HttpGet, ActionName("CLOrder")]
        public async Task<IActionResult> CreateCLOrder()
        {
            await Task.Run(() => { 
                var ddlProduct = from s in _context.Stock
                                 join p in _context.Products on s.ProductId equals p.Id
                                 select new { ProductCode = p.ProductCode + "( Available Qty: " + s.AvailableQuantity + " )", Id = p.Id };
                ViewData["Product"] = new SelectList(ddlProduct, "Id", "ProductCode");           
            });
            return View("CreateCLOrder", new CreateCLOrderVM());
        }

        [HttpPost, ActionName("CreateCLOrder")]
        public JsonResult CreateCLOrder(CreateCLOrderVM model)
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
                        model.Order.OrderStatus = DefaultValues.OrderStatus.Process.ToString();

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
                        return result = Json(new { success = true, message = " Order successfully placed.", redirectUrl = @"/Orders/CLOrderInvoice?orderId=" + model.Order.Id });

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
        [HttpGet, ActionName("GetCLLastRX")]
        public async Task<IActionResult> GetCLLastRX(string jsonData)
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

        [HttpGet, ActionName("CLOrderInvoice")]
        public async Task<IActionResult> CLInvoice(long? orderId)
        {
            var result = (dynamic)null;
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return result = Json(new { success = false, message = " Order details are not found.", redirectUrl = "/Technical/{404}" });
            }

            var getUser = _context.Users.Where(u => u.Id == order.UserId).FirstOrDefault();
            var getPersonalInfo = await _context.PersonalDetail.Where(u => u.UserId == order.UserId).FirstOrDefaultAsync();
            var contactLense = await _context.ContactLenseRx.Where(u => u.UserId == order.UserId).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();
            var orderDetails = from od in _context.OrderDetails
                               where od.OrderId == order.Id
                               join p in _context.Products on od.ProductId equals p.Id
                               select new Models.PageModels.OrdersVM.CLOrderInvoice.ListOfOrderDetail
                               {
                                   OrderDetail = od,
                                   Product = p
                               };
            //Get Payments records
            var getPayments = _context.Payment.Where(p => p.InstrumentNo == order.OrderNo);

            var model = new CLOrderInvoiceVM()
            {
                Order = order,
                User = getUser,
                PersonalDetail = getPersonalInfo,
                ContactLense = contactLense,
                ListOrderDetails = orderDetails.ToList(),
                TotalAmount = order.GrandTotal,
                PaidAmount = getPayments == null ? 0 : getPayments.Sum(s => s.PaidAmount),
                QrCode = _cmnFunction.CreateQrCode(string.Format("#:{0}, OrderNo:{1}, OrderDate:{2}, TotalPrice:{3}", order.Id, order.OrderNo, order.OrderPlaceDate, order.GrandTotal))
            };
            model.DueAmount = model.TotalAmount - model.PaidAmount;
            ViewData["PaymentMethods"] = new SelectList(_context.PaymentMethods, "Id", "Name");

            return View("Invoices/CLOrderInvoice", model);
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

        #region Spectacle Order GetMethods
        [HttpGet, ActionName("SpecOrder")]
        public async Task<IActionResult> CreateSpecOrder()
        {
            await Task.Run(() => {
                var ddlProduct = from s in _context.Stock
                                 join p in _context.Products on s.ProductId equals p.Id
                                 select new { ProductCode = p.ProductCode + "( Available Qty: " + s.AvailableQuantity + " )", Id = p.Id };
                ViewData["Product"] = new SelectList(ddlProduct, "Id", "ProductCode");
            });
            return View("CreateSpecOrder");
        }

        [HttpPost, ActionName("CreateSpecOrder")]
        public JsonResult CreateSpecOrder(CreateSpecOrderVM model)
        {
            var result = (dynamic)null;
            try
            {

                if (model.SpectacleRx != null && model.Users != null)
                {

                    using (TransactionScope transaction = new TransactionScope())
                    {

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
                        if (model.SpectacleRx.Id > 0)
                        {
                            //Update if record exist
                            var preSpec = _context.SpectacleRx.Find(model.SpectacleRx.Id);

                            model.SpectacleRx.UserId = preSpec.UserId;
                            model.SpectacleRx.CreatedDate = preSpec.CreatedDate;
                            model.SpectacleRx.UpdatedDate = DateTime.UtcNow;
                            model.SpectacleRx.CheckedBy = 0;
                            model.SpectacleRx.CheckedDate = null;

                            _context.Entry(preSpec).CurrentValues.SetValues(model.SpectacleRx);
                            _context.SaveChanges();
                        }
                        else
                        {
                            //Create new if not record exist
                            model.SpectacleRx.UserId = model.Users.Id;
                            model.SpectacleRx.CreatedDate = DateTime.UtcNow;
                            _context.SpectacleRx.Add(model.SpectacleRx);
                            _context.SaveChanges();
                        }
                        //Importing Order Master record...
                        model.Order.UserId = model.Users.Id;
                        model.Order.GrandTotal = model.ListOrderDetails.Sum(s => s.Total);
                        model.Order.BillingAddress = model.Order.BillingAddress;
                        model.Order.OrderPlaceDate = DateTime.Now;
                        model.Order.CollectionDate = model.Order.CollectionDate;
                        model.Order.OrderStatus = DefaultValues.OrderStatus.Process.ToString();
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
                                return result = Json(new { success = false, message = " Order can't proceed, " + currentStock.p.ProductCode + " out of stock.", redirectUrl = "" });
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
                        return result = Json(new { success = true, message = " Order successfully placed.", redirectUrl = @"/Orders/SpecOrderInvoice?orderId=" + model.Order.Id });
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
        [HttpGet, ActionName("GetSpecLastRX")]
        public async Task<IActionResult> GetSpecLastRX(string jsonData)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<Users>(jsonData);
                var result = await _context.SpectacleRx.Where(u => u.UserId == user.Id).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet, ActionName("SpecOrderInvoice")]
        public async Task<IActionResult> SpecInvoice(long? orderId)
        {
            var result = (dynamic)null;
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return result = Json(new { success = false, message = " Order details are not found.", redirectUrl = "/Technical/{404}" });
            }

            var getUser = _context.Users.Where(u => u.Id == order.UserId).FirstOrDefault();
            var getPersonalInfo = await _context.PersonalDetail.Where(u => u.UserId == order.UserId).FirstOrDefaultAsync();
            var spectacle = await _context.SpectacleRx.Where(u => u.UserId == order.UserId).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();
            var orderDetails = from od in _context.OrderDetails
                               where od.OrderId == order.Id
                               join p in _context.Products on od.ProductId equals p.Id
                               select new Models.PageModels.OrdersVM.SpecOrderInvoice.ListOfOrderDetail
                               {
                                   OrderDetail = od,
                                   Product = p
                               };
            //Get Payments records
            var getPayments = _context.Payment.Where(p => p.InstrumentNo == order.OrderNo);

            var model = new SpecOrderInvoiceVM()
            {
                Order = order,
                User = getUser,
                PersonalDetail = getPersonalInfo,
                Spectacle = spectacle,
                ListOrderDetails = orderDetails.ToList(),
                TotalAmount = order.GrandTotal,
                PaidAmount = getPayments == null ? 0 : getPayments.Sum(s => s.PaidAmount),
                QrCode = _cmnFunction.CreateQrCode(string.Format("#:{0}, OrderNo:{1}, OrderDate:{2}, TotalPrice:{3}", order.Id, order.OrderNo, order.OrderPlaceDate, order.GrandTotal))
            };
            model.DueAmount = model.TotalAmount - model.PaidAmount;
            ViewData["PaymentMethods"] = new SelectList(_context.PaymentMethods, "Id", "Name");

            return View("Invoices/SpecOrderInvoice", model);
        }

        #endregion

        #region Cash&Carry Order
        [HttpGet, ActionName("CCOrder")]
        public async Task<IActionResult> CreateCCOrder()
        {
            await Task.Run(() => {
                var ddlProduct = from s in _context.Stock
                                 join p in _context.Products on s.ProductId equals p.Id
                                 select new { ProductCode = p.ProductCode + " ( Available Qty: " + s.AvailableQuantity + " )", Id = p.Id };
                ViewData["Product"] = new SelectList(ddlProduct, "Id", "ProductCode");
            });
            return View("CreateCCOrder");
        }

        [HttpPost, ActionName("CreateCCOrder")]
        public JsonResult CreateCCOrder(CreateCCOrderVM model)
        {
            var result = (dynamic)null;
            try
            {

                if (model.Users != null)
                {

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        var newOrder = new Orders();
                        Orders lastOrder = _context.Orders.OrderByDescending(o => o.OrderPlaceDate).FirstOrDefault();

                        //Order No generating...
                        if (lastOrder != null)
                        {
                            int newOrderNo = Convert.ToInt32(lastOrder.OrderNo.Substring(10)) + 1;
                            newOrder.OrderNo = _cmnBusinessFunction.GenerateNumberWithPrefix("ORD-", newOrderNo.ToString());
                        }
                        else
                        {
                            newOrder.OrderNo = _cmnBusinessFunction.GenerateNumberWithPrefix("ORD-", 1.ToString());
                        }

                        //Importing Order Master record...
                        newOrder.UserId = model.Users.Id;
                        newOrder.GrandTotal = model.ListOrderDetails.Sum(s => s.Total);
                        newOrder.OrderPlaceDate = DateTime.Now;
                        newOrder.CollectionDate = DateTime.UtcNow;
                        newOrder.OrderStatus = DefaultValues.OrderStatus.Approved.ToString();
                        _context.Orders.Add(newOrder);
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
                                return result = Json(new { success = false, message = " Order can't proceed, " + currentStock.p.ProductCode + " out of stock.", redirectUrl = "" });
                            }

                            item.OrderId = newOrder.Id;
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
                                ReferenecId = newOrder.OrderNo,
                                TableReference = "Sales Order",
                                Note = "Generated From Orders/CreateCCOrder"
                            });
                        }

                        transaction.Complete();
                        return result = Json(new { success = true, message = " Order successfully placed.", redirectUrl = @"/Orders/CCOrderInvoice?orderId=" + newOrder.Id });
                        //return RedirectToAction("CCOrderInvoice", new { orderId =  newOrder.Id });
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

        [HttpGet, ActionName("CCOrderInvoice")]
        public async Task<IActionResult> CCInvoice(long? orderId)
        {
            var result = (dynamic)null;
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return result = Json(new { success = false, message = " Order details are not found.", redirectUrl = "/Technical/{404}" });
            }

            var getUser = _context.Users.Where(u => u.Id == order.UserId).FirstOrDefault();
            var getPersonalInfo = _context.PersonalDetail.Where(u => u.UserId == order.UserId).FirstOrDefault();
            var orderDetails = from od in _context.OrderDetails
                               where od.OrderId == order.Id
                               join p in _context.Products on od.ProductId equals p.Id
                               select new Models.PageModels.OrdersVM.CCOrderInvoice.ListOfOrderDetail
                               {
                                   OrderDetail = od,
                                   Product = p
                               };
            //Get Payments records
            var getPayments = _context.Payment.Where(p => p.InstrumentNo == order.OrderNo);

            var model = new CCOrderInvoiceVM()
            {
                Order = order,
                User = getUser,
                PersonalDetail = getPersonalInfo,
                ListOrderDetails = orderDetails.ToList(),
                TotalAmount = order.GrandTotal,
                PaidAmount = getPayments == null ? 0 : getPayments.Sum(s => s.PaidAmount),
                QrCode = _cmnFunction.CreateQrCode(string.Format("#:{0}, OrderNo:{1}, OrderDate:{2}, TotalPrice:{3}", order.Id, order.OrderNo, order.OrderPlaceDate, order.GrandTotal))
            };
            model.DueAmount = model.TotalAmount - model.PaidAmount;
            ViewData["PaymentMethods"] = new SelectList(_context.PaymentMethods, "Id", "Name");

            return View("Invoices/CCOrderInvoice", model);
        }

        #endregion

        #region Revceive OrdersPayment
        [HttpPost, ActionName("CreatePayment")]
        public JsonResult OrderPayment(Models.PageModels.PaymentsVM.PaymentsVM model)
        {
            var result = (dynamic)null;
            try
            {

                if (model != null)
                {

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        var newPayment = new Payment();
                        Payment lastPayment = _context.Payment.OrderByDescending(o => o.TransactionDate).FirstOrDefault();

                        //Order No generating...
                        if (lastPayment != null)
                        {
                            int newPaymentNo = Convert.ToInt32(lastPayment.TransactionNo.Substring(10)) + 1;
                            newPayment.TransactionNo = _cmnBusinessFunction.GenerateNumberWithPrefix("TRN-", newPaymentNo.ToString());
                        }
                        else
                        {
                            newPayment.TransactionNo = _cmnBusinessFunction.GenerateNumberWithPrefix("TRN-", 1.ToString());
                        }

                        //Creating new payment record...
                        newPayment.UserId = model.UserId;
                        newPayment.InstrumentNo = model.OrderNo;
                        newPayment.TransactionDate = DateTime.UtcNow;
                        newPayment.PaidAmount = model.PaidAmount;
                        newPayment.PaymentMethodId = model.PaymentMethodId;
                        newPayment.TableReference = "Orders";
                        _context.Payment.Add(newPayment);
                        _context.SaveChanges();

                        transaction.Complete();
                        return result = Json(new { success = true, message = " Payment successfully Done.", redirectUrl = model.RedirectLink + "?orderId=" + model.OrderId });
                    }
                }
                else
                    return result = Json(new { success = false, message = "Payment Failed!.", redirectUrl = "" });
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
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

        #region RemoteValidation

        #endregion RemoteValidation

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

        #region OrderSearchMethods

        [Produces("application/json")]
        [HttpGet, ActionName("OrderSearch")]
        public async Task<IActionResult> OrderSearch()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var result = await _context.Orders.Where(p => p.OrderNo.Contains(term)).Select(p => p.OrderNo).ToListAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [HttpGet, ActionName("OrderSearchResult")]
        public async Task<IActionResult> OrderSearchResult(string orderNo)
        {
            try
            {
                var pageNumber = 1;
                int pageRowSize = 20;
                string orderStatus = "";

                var fetchOrders = new List<OrdersVM>();

                var fetchOrder = from o in _context.Orders
                                 where o.OrderNo == orderNo
                                 join u in _context.Users on o.UserId equals u.Id
                                 join ut in _context.UserType on u.UserTypeId equals ut.Id
                                 join pd in _context.PersonalDetail on u.Id equals pd.UserId
                                 orderby o.OrderPlaceDate descending
                                 select new OrdersVM
                                 {
                                     Orders = o,
                                     Users = u,
                                     UserType = ut,
                                     PersonalDetail = pd
                                 };
                fetchOrders = fetchOrder.ToList();

                var orders = new List<OrdersVM>();
                foreach (var item in fetchOrders)
                {
                    var orderVm = new OrdersVM();
                    orderVm.Orders = item.Orders;
                    orderVm.Users = item.Users;
                    orderVm.UserType = item.UserType;
                    orderVm.PersonalDetail = item.PersonalDetail;

                    //Fetch Payment data.
                    var paidAmounts = _context.Payment.Where(p => p.InstrumentNo == item.Orders.OrderNo) == null ? 0 : (decimal)_context.Payment.Where(p => p.InstrumentNo == item.Orders.OrderNo).Sum(s => s.PaidAmount);
                    orderVm.PaidAmount = paidAmounts;
                    orderVm.DueAmount = (decimal)(item.Orders.GrandTotal - paidAmounts);

                    if (paidAmounts == 0)
                    {
                        orderVm.PaidStatus = "Not Paid";
                    }
                    if (paidAmounts >= item.Orders.GrandTotal)
                    {
                        orderVm.PaidStatus = "Full Paid";
                    }
                    if (paidAmounts > 0 && paidAmounts < item.Orders.GrandTotal)
                    {
                        orderVm.PaidStatus = "Partial Paid";
                    }
                    orders.Add(orderVm);
                }

                ViewData["ddlOrderStatus"] = new SelectList(
                    from DefaultValues.OrderStatus e in Enum.GetValues(typeof(DefaultValues.OrderStatus))
                    select new { Id = (int)e, Name = e.ToString() }, "Id", "Name");

                ViewData["SelectedOrderStatus"] = string.IsNullOrEmpty(orderStatus) ? "All" : orderStatus;
                ViewData["PageNumber"] = pageNumber;
                ViewData["SearchValue"] = orderNo;
                var result = await orders.ToPagedListAsync(pageNumber, pageRowSize);

                return View("SearchOrders", result);
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                return BadRequest();
            }
        }

        #endregion
    }
}
