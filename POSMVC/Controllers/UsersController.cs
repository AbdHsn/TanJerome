using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonLogics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.UsersVM;
using X.PagedList;

namespace POSMVC.Controllers
{
    public class UsersController : Controller
    {

        #region Global Variables
        private readonly EyePosDBContext _context;
        private readonly IMapper _mapper;
        private readonly CommonFunctions _cmnFunction;
        private readonly IHostingEnvironment _he;
        #endregion

        #region Constructor
        public UsersController(
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
        public async Task<IActionResult> Customers(int? page, int? ddlId)
        {
            var pageNumber = page ?? 1;
            int pageRowSize = 10;
            int userTypeId = ddlId ?? 0;

            var customers = new List<ListUser>();
            var customerTypes = new List<int> { 4, 5, 6, 7 };

            if (userTypeId == 0)
            {

                var users = from u in _context.Users
                            where customerTypes.Contains(Convert.ToInt32(u.UserTypeId))
                            join ut in _context.UserType on u.UserTypeId equals ut.Id
                            join pd in _context.PersonalDetail on u.Id equals pd.UserId
                            select new ListUser { User = u, UserType = ut, PersonalDetail = pd };
                customers = await users.ToListAsync();
            }
            else
            {
                var users = from u in _context.Users
                            join ut in _context.UserType on u.UserTypeId equals ut.Id
                            join pd in _context.PersonalDetail on u.Id equals pd.UserId
                            where u.UserTypeId == ddlId
                            select new ListUser { User = u, UserType = ut, PersonalDetail = pd };
                customers = await users.ToListAsync();
            }

            ViewData["UserTypeId"] = new SelectList(_context.UserType.Where(u => customerTypes.Contains(u.Id)), "Id", "TypeName", userTypeId);
            ViewData["SelectedUserTypeName"] = userTypeId == 0 ? "All" : _context.UserType.Find(userTypeId).TypeName;


            var result = customers.ToPagedList(pageNumber, pageRowSize);

            return View(result);
        }

        [HttpGet, ActionName("CreateCustomer")]
        public async Task<IActionResult> Create()
        {
            var customerTypes = new List<int> { 4, 5, 6, 7 };

            ViewData["UserTypeId"] = new SelectList(await _context.UserType.Where(u => customerTypes.Contains(u.Id)).ToListAsync(), "Id", "TypeName");
            return PartialView("_CreateCustomer", new CreateUserVM());
        }

        [HttpGet, ActionName("EditCustomer")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id != 0)
            {
                var customerTypes = new List<int> { 4, 5, 6, 7 };
                var userVM = new EditUserVM()
                {

                    Users = await _context.Users.FindAsync(id),
                    PersonalDetail = await _context.PersonalDetail.Where(p => p.UserId == id).FirstOrDefaultAsync()
                };
                ViewData["UserTypeId"] = new SelectList(_context.UserType.Where(u => customerTypes.Contains(u.Id)), "Id", "TypeName", userVM.Users.UserTypeId);
                return PartialView("_UpdateCustomer", userVM);
            }
            else
            {
                ViewData["UserTypeId"] = new SelectList(_context.UserType, "Id", "TypeName");
                return PartialView("_UpdateCustomer", new EditUserVM());
            }
        }

        #endregion

        #region PostMethods

        [HttpPost, ActionName("CreateCustomer")]
        public async Task<JsonResult> CreateCustomer(CreateUserVM user)
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
                    return result = Json(new { success = true, message = user.PersonalDetail.Name + " successfully created.", redirectUrl = @"/Users/Customers" });
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

        [HttpPost, ActionName("EditCustomer")]
        public async Task<JsonResult> Edit(EditUserVM editUserVM)
        {
            var result = (dynamic)null;

            try
            {
                if (editUserVM.Users.Id <= 0)
                {
                    return result = Json(new { success = false, message = " Record is not found", redirectUrl = @"/Users/Customers" });
                }

                var personalDetail = await _context.PersonalDetail.Where(pd => pd.UserId == editUserVM.Users.Id).FirstOrDefaultAsync();

                personalDetail.Name = editUserVM.PersonalDetail.Name;
                personalDetail.Gender = editUserVM.PersonalDetail.Gender;
                personalDetail.MobileNo = editUserVM.PersonalDetail.MobileNo;
                personalDetail.OtherPhone = editUserVM.PersonalDetail.OtherPhone;
                personalDetail.Dob = editUserVM.PersonalDetail.Dob;
                personalDetail.Address = editUserVM.PersonalDetail.Address;

                _context.PersonalDetail.Update(personalDetail);
                await _context.SaveChangesAsync();

                var user = await _context.Users.FindAsync(editUserVM.Users.Id);
                //if (editUserVM.file != null)
                //{
                ////Delete previous physical image if exist
                //if (!string.IsNullOrEmpty(user.SmallImage)) { 
                //    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, user.SmallImage)); 
                //}
                //if (!string.IsNullOrEmpty(user.BigImage)) { 
                //    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, user.BigImage));
                //}

                //string smallImage = "StaticFiles/Users/SmallImage/";
                //string bigImage = "StaticFiles/Users/BigImage/";
                //string extension = Path.GetExtension(editUserVM.file.FileName);

                ////Place updated image into server
                //if (_cmnFunction.SaveImage(editUserVM.file, user.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
                //{
                //    user.SmallImage = smallImage + user.Id.ToString() + extension;
                //}

                //if (_cmnFunction.SaveImage(editUserVM.file, user.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
                //{
                //    user.BigImage = bigImage + user.Id.ToString() + extension;
                //}
                //}
                user.UserTypeId = editUserVM.Users.UserTypeId;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return result = Json(new { success = true, message = "Record successfully updated", redirectUrl = @"/Users/Customers" });
            }
            catch (Exception ex)
            {
                string err = @"Exception occured at Users/EditPeople " + ex.ToString();
                return result = Json(new { success = false, message = "Operation failed. Contact with system admin.", redirectUrl = "" });
            }
        }

        [HttpPost, ActionName("DeleteCustomer")]
        public async Task<JsonResult> Delete(Users model)
        {
            var result = (dynamic)null;
            try
            {
                var customer = await _context.Users.Where(c => c.Id == model.Id).FirstOrDefaultAsync();
                var chPersonalDetails = await _context.PersonalDetail.Where(p => p.UserId == model.Id).FirstOrDefaultAsync();

                if (customer != null)
                {
                    ////Delete  physical image file
                    //if (!string.IsNullOrEmpty(customer.BigImage))
                    //    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, customer.BigImage));

                    //if (!string.IsNullOrEmpty(customer.SmallImage))
                    //    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, customer.SmallImage));

                    //Delete child records from database.
                    _context.PersonalDetail.Remove(chPersonalDetails);

                    //Delete parent record from database.
                    _context.Users.Remove(customer);
                    await _context.SaveChangesAsync();

                    return result = Json(new { success = true, message = " Record successfully deleted.", redirectUrl = @"/Users/Customers" });
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

        #region SearchMethods

        [Produces("application/json")]
        [HttpGet, ActionName("CustomerSearch")]
        public async Task<IActionResult> Search()
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


        [HttpGet, ActionName("SearchResult")]
        public async Task<IActionResult> SearchResult(string mobile)
        {
            var pageNumber = 1;
            int pageRowSize = 10;
            int userTypeId = 0;

            var mobileNo = mobile.Split(" (").FirstOrDefault();

            var customers = new List<ListUser>();

            var customerTypes = new List<int> { 4, 5, 6, 7 };

            if (userTypeId == 0)
            {
                var personalD = _context.PersonalDetail.Where(p => p.MobileNo == mobileNo);
                var users = from u in _context.Users
                            where customerTypes.Contains(Convert.ToInt32(u.UserTypeId))
                            join ut in _context.UserType on u.UserTypeId equals ut.Id
                            join pd in personalD on u.Id equals pd.UserId
                            select new ListUser { User = u, UserType = ut, PersonalDetail = pd };
                customers = await users.ToListAsync();
            }

            ViewData["UserTypeId"] = new SelectList(_context.UserType.Where(u => customerTypes.Contains(u.Id)), "Id", "TypeName", userTypeId);
            ViewData["SelectedUserTypeName"] = userTypeId == 0 ? "All" : _context.UserType.Find(userTypeId).TypeName;
            ViewData["SearchValue"] = mobile;

            var result = customers.ToPagedList(pageNumber, pageRowSize);
            return View("SearchCustomer", result);
        }
        #endregion

    }
}
