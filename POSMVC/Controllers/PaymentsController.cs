using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using CommonLogics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using POSMVC.CommonBusinessFunctions;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.OrdersVM;
using POSMVC.Models.PageModels.PaymentsVM;
using X.PagedList;
using static POSMVC.Models.PageModels.PaymentsVM.GetTransactionVM;

namespace POSMVC.Controllers
{
    public class PaymentsController : Controller
    {

        #region Global Variables
        private readonly EyePosDBContext _context;
        private readonly CommonFunctions _cmnFunction;
        private readonly CommonBusinessLogics _cmnBusinessFunction;
        private readonly IHostingEnvironment _he;
        #endregion

        #region Constructor
        public PaymentsController(
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
        public async Task<IActionResult> GetTransaction(GetTransactionVM model)
        {
            var result = (dynamic)null;
  
            if (model.FromDate != null && model.ToDate != null)
            {
                    var fetchPayment = from p in _context.Payment
                                       where p.TransactionDate.Value.Date >= model.FromDate.Value.Date
                                       && p.TransactionDate.Value.Date < model.ToDate.Value.Date.AddDays(1)
                                       join u in _context.Users on p.UserId equals u.Id
                                       orderby p.TransactionDate descending
                                       select new ListPayment
                                       {
                                           Payment = p,
                                           User = u
                                       };

                result = new GetTransactionVM()
                {
                    lstPayment = fetchPayment.ToList(),
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                    TotalRecords = fetchPayment.Count(),
                    TotalPaid = (decimal)fetchPayment.Sum(s => s.Payment.PaidAmount),
                };
                return View(result);
            }
            else if(!string.IsNullOrEmpty(model.OrderNo))
            {
                var fetchPayment = from p in _context.Payment
                                   where p.InstrumentNo == model.OrderNo
                                   join u in _context.Users on p.UserId equals u.Id
                                   orderby p.TransactionDate descending
                                   select new ListPayment
                                   {
                                       Payment = p,
                                       User = u
                                   };

                result = new GetTransactionVM()
                {
                    lstPayment = fetchPayment.ToList(),
                    OrderNo = model.OrderNo,
                    TotalRecords = fetchPayment.Count(),
                    TotalPaid = (decimal)fetchPayment.Sum(s => s.Payment.PaidAmount),
                };
                return View(result);
            }

            return View(result);
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

                model = new Models.PageModels.OrdersVM.PaymentsVM()
                {
                    Orders = order,
                    ListPayments = payments.ToList(),
                    TotalPaidAmount = (decimal)payments.Sum(s => s.Payment.PaidAmount),

                };
                model.DueAmount = (decimal)(order.GrandTotal - model.TotalPaidAmount);
            }
            return PartialView("_Transactions", model);
        }


        #region Revceive Order Late Payment
        [HttpGet, ActionName("ReceiveLatePayment")]
        public async Task<IActionResult> ReceiveLatePayment()
        {
            return View("ReceivePayment/ReceiveLatePayment");
        }


        [HttpGet, ActionName("GetPaymentDetails")]
        public async Task<IActionResult> GetPaymentDetails(string orderNo)
        {
            var order = await _context.Orders.Where(o => o.OrderNo == orderNo).FirstOrDefaultAsync();
            var payments = from p in _context.Payment
                           where p.InstrumentNo == order.OrderNo
                           join pm in _context.PaymentMethods on p.PaymentMethodId equals pm.Id
                           select new ListPayments
                           {
                               Payment = p,
                               PaymentMethods = pm
                           };
            var orderDetails = from od in _context.OrderDetails
                               where od.OrderId == order.Id
                               join p in _context.Products on od.ProductId equals p.Id
                               select new ListOrderDetails
                               {
                                   OrderDetails = od,
                                   Products = p
                               };

            decimal totalPaid = (decimal)payments.Sum(s => s.Payment.PaidAmount);

            var returnModel = new GetPaymentDetailsVM() { 
                lstOrderDetails = orderDetails,
                lstPayment = payments,
                Order = order,
                User = await _context.Users.FindAsync(order.UserId),
                PersonalDetail = _context.PersonalDetail.Where(p => p.UserId == order.UserId).FirstOrDefault(),
                TotalPaid = totalPaid,
                Due = (decimal)order.GrandTotal - totalPaid
            };
            ViewData["PaymentMethods"] = new SelectList(_context.PaymentMethods, "Id", "Name");
            return PartialView("ReceivePayment/_GetPaymentDetails", returnModel);
        }

        [HttpPost, ActionName("ReceiveLatePayment")]
        public JsonResult ReceiveLatePayment(GetPaymentDetailsVM model)
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
                        newPayment.UserId = model.Order.UserId;
                        newPayment.InstrumentNo = model.Order.OrderNo;
                        newPayment.TransactionDate = DateTime.UtcNow;
                        newPayment.PaidAmount = model.PayAmount;
                        newPayment.PaymentMethodId = model.PaymentMethodId;
                        newPayment.TableReference = "Orders";
                        _context.Payment.Add(newPayment);
                        _context.SaveChanges();

                        transaction.Complete();
                        return result = Json(new { success = true, message = " Payment successfully Done.", redirectUrl = "/Orders/CCOrderInvoice?orderId=" + model.Order.Id });
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

        #region Revceive Order Instant Payment
        [HttpPost, ActionName("ReceiveInstantPayment")]
        public JsonResult ReceiveInstantPayment(Models.PageModels.PaymentsVM.PaymentsVM model)
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
            catch (Exception ex)
            {
                string err = ex.ToString();
                return BadRequest();
            }
        }

        #endregion

    }
}
