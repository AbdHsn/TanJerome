
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace HRS.Controllers
//{
//    public class AccountsController : Controller
//    {
//        #region Variables
//        private readonly HRSDBContext _hRSDBContext;
//        private readonly ICommonFunctions _commonFunction;
//        private readonly IHostingEnvironment _he;
//        #endregion Variables

//        #region Constructor
//        public AccountsController(HRSDBContext hRSDBContext, ICommonFunctions commonFunction, IHostingEnvironment e)
//        {
//            _hRSDBContext = hRSDBContext;
//            _commonFunction = commonFunction;
//            _he = e;
//        }
//        #endregion Constructor

//        #region LogIn Methods
//        [HttpGet]
//        [AllowAnonymous]
//        public IActionResult LogIn()
//        {
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<IActionResult> LogIn(LogInVM model)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    //[Hints: Check user is exist or not base on user's input]
//                    var isAuthentic = from user in _hRSDBContext.Users
//                                      where (user.Password == model.Password) && (user.Email == model.EmailOrUserName || user.UserName == model.EmailOrUserName)
//                                      select user;

//                    if (isAuthentic.Count() != 0)
//                    {
//                        // Join Query with Authorization and Actors]
//                        var _authorizations = from au in _hRSDBContext.Authorizations
//                                              join ac in _hRSDBContext.Actors
//                                              on au.ActorId equals ac.Id
//                                              where au.UserId == isAuthentic.SingleOrDefault().Id
//                                              select new { au, ac };

//                        // Create empty claim list and loop for adding user specific role from Authorization access]
//                        var claims = new List<Claim>();
//                        foreach (var item in _authorizations)
//                        {
//                            claims.Add(new Claim(ClaimTypes.Role, item.ac.Name));
//                        }
//                        claims.Add(new Claim(ClaimTypes.NameIdentifier, isAuthentic.SingleOrDefault().Id.ToString()));
//                        claims.Add(new Claim(ClaimTypes.Name, "Hi, " + isAuthentic.SingleOrDefault().FirstName + " " + isAuthentic.SingleOrDefault().LastName));
//                        //  create identity] 
//                        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//                        //  create principal]
//                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
//                        //  sign-in]
//                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
//                        model.IsSuccess = true;
//                        return RedirectToAction("Index", "Home");
//                    }

//                }
//                catch (Exception ex)
//                {
//                    string error = ex.ToString();
//                    model.IsSuccess = false;
//                    ViewBag.message = model.Message = "Error:#0012,Account:LogIn - Operation failed.";
//                    return View(model);
//                }

//            }
//            model.IsSuccess = false;
//            ViewBag.message = model.Message = "Invalid loging attempt.";
//            return View(model);
//        }
//        [AllowAnonymous]
//        public async Task<IActionResult> LogOut()
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return RedirectToAction("Index", "Home");
//        }
//        #endregion LogIn Methods

//        #region Registration Methods
//        [HttpGet]
//        [AllowAnonymous]
//        public IActionResult UserRegistration()
//        {
//            return View();
//        }
//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<IActionResult> UserRegistration(UserRegistrationVM model)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    //[Hints: New User Creation]
//                    var userLastId = _hRSDBContext.Users.ToList().LastOrDefault();
//                    var newUser = new Users()
//                    {
//                        Id = userLastId == null ? 1 : userLastId.Id + 1,
//                        FirstName = model.FirstName,
//                        LastName = model.LastName,
//                        Email = model.Email,
//                        UserName = model.Email,
//                        Password = model.Password,
//                        UserCreatedDate = DateTime.Now.Date
//                    };
//                    await _hRSDBContext.Users.AddAsync(newUser);
//                    await _hRSDBContext.SaveChangesAsync();
//                    //[~Hints: New User Creation]

//                    //[Hints: New Authorization Creation]
//                    var authorizeLastId = _hRSDBContext.Authorizations.ToList().LastOrDefault();
//                    var newAuthorization = new Authorizations()
//                    {
//                        Id = authorizeLastId == null ? 1 : authorizeLastId.Id + 1,
//                        ActorId = 2,
//                        UserId = newUser.Id,
//                        IsActive = true,
//                        AddedDate = DateTime.UtcNow
//                    };
//                    await _hRSDBContext.Authorizations.AddAsync(newAuthorization);
//                    await _hRSDBContext.SaveChangesAsync();
//                    //[~Hints: New User Creation]

//                    //  join Query with Authorization and Actors]
//                    var _authorizations = from au in _hRSDBContext.Authorizations
//                                          join ac in _hRSDBContext.Actors
//                                          on au.ActorId equals ac.Id
//                                          where au.UserId == newUser.Id
//                                          select new { au, ac };

//                    //[Hints: New Identity Creation and give user logged in.]
//                    //  create empty claim list and loop for adding user specific role from Authorization access
//                    var claims = new List<Claim>();
//                    foreach (var item in _authorizations)
//                    {
//                        claims.Add(new Claim(ClaimTypes.Role, item.ac.Name));
//                    }
//                    claims.Add(new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()));
//                    claims.Add(new Claim(ClaimTypes.Name, "Hi, " + model.FirstName + " " + model.LastName));
//                    //  create identity 
//                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//                    //  create principal
//                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
//                    //  sign-in
//                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
//                    //[~Hints: New Identity Creation and give user logged in.]
//                    model.IsSuccess = true;
//                    return RedirectToAction("Index", "Home");
//                }
//                catch (Exception ex)
//                {
//                    string error = ex.ToString();
//                    model.IsSuccess = false;
//                    ViewBag.message = model.Message = "Error:#0012,Account:Registration - Operation failed.";
//                    return View(model);
//                }
//            }
//            model.IsSuccess = false;
//            ViewBag.message = model.Message = "Registration is not completed.";
//            return View(model);
//        }

//        [HttpGet]
//        [AllowAnonymous]
//        public IActionResult HotelRegistration()
//        {
//            return View();
//        }
//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<IActionResult> HotelRegistration(HotelRegistrationVM model, IFormFile file)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    //[Hints: New Hotel Creation]
//                    var hotelLastId = _hRSDBContext.Hotels.ToList().LastOrDefault();
//                    var hotelAlbumId = _hRSDBContext.HotelAlbums.ToList().LastOrDefault();
//                    var hotelAlbumDetailsId = _hRSDBContext.HotelAlbumDetails.ToList().LastOrDefault() == null ? 1 : _hRSDBContext.HotelAlbumDetails.ToList().LastOrDefault().Id + 1;
//                    string imagePath = "StaticFiles/ClientFiles/HotelAlbumDetails/";

//                    var newHotel = new Hotels()
//                    {
//                        Id = hotelLastId == null ? 1 : hotelLastId.Id + 1,
//                        Name = model.Name
//                    };
//                    await _hRSDBContext.Hotels.AddAsync(newHotel);
//                    await _hRSDBContext.SaveChangesAsync();

//                    var hotelAlbum = new HotelAlbums()
//                    {
//                        Id = hotelAlbumId == null ? 1 : hotelAlbumId.Id + 1,
//                        HotelId = newHotel.Id,
//                        Name = "Default"
//                    };
//                    _hRSDBContext.HotelAlbums.Add(hotelAlbum);
//                    await _hRSDBContext.SaveChangesAsync();

//                    var hotelAlbumDetails = new HotelAlbumDetails()
//                    {
//                        Id = hotelAlbumDetailsId,
//                        HotelAlbumId = hotelAlbum.Id,
//                        Location = imagePath + hotelAlbumDetailsId + ".jpg"
//                    };
//                    _hRSDBContext.HotelAlbumDetails.Add(hotelAlbumDetails);
//                    await _hRSDBContext.SaveChangesAsync();
//                    //Image Save

//                    _commonFunction.SaveImage(hotelAlbumDetails.Id.ToString(), file, Path.Combine(_he.WebRootPath, imagePath), 400, 300, ".jpg");

//                    //[Hints: Getting userId]
//                    var UserId = _hRSDBContext.Users.Where(u => u.Email == model.Email).SingleOrDefault();
//                    //[~Hints: Getting userId]
//                    //[Hints: New Authorization Creation]
//                    var authorizeLastId = _hRSDBContext.Authorizations.ToList().LastOrDefault();
//                    var newAuthorization = new Authorizations()
//                    {
//                        Id = authorizeLastId == null ? 1 : authorizeLastId.Id + 1,
//                        ActorId = 3,
//                        UserId = UserId.Id,
//                        HotelId = newHotel.Id,
//                        IsActive = true,
//                        AddedDate = DateTime.UtcNow
//                    };
//                    await _hRSDBContext.Authorizations.AddAsync(newAuthorization);
//                    await _hRSDBContext.SaveChangesAsync();
//                    //[~Hints: New Authorization Creation]

//                    model.IsSuccess = true;
//                    ViewBag.successMessage = model.Message = "We've successfully created an account for your hotel. Please log into your account and get access on it.";

//                }
//                catch (Exception ex)
//                {
//                    string error = ex.ToString();
//                    model.IsSuccess = false;
//                    ViewBag.errorMessage = model.Message = "Error:#0012,Account:HotelRegistration - Operation failed.";
//                }
//            }
//            return View(model);
//        }

//        #endregion Registration Methods

//        #region Unauthorize Handling Methods
//        public IActionResult Denied()
//        {
//            return View();
//        }

//        public IActionResult NotLogIn()
//        {
//            return View();
//        }
//        #endregion Unauthorize Handling Methods

//        #region RemoteValidation
//        [AcceptVerbs("Get", "Post")]
//        [AllowAnonymous]
//        public IActionResult IsEmailExist(string email)
//        {
//            var user = _hRSDBContext.Users.Where(u => u.Email == email).SingleOrDefault();
//            if (user == null)
//            {
//                return Json(true);
//            }
//            else
//            {
//                return Json($"This email '{email}' is already used.");
//            }
//        }

//        [AcceptVerbs("Get", "Post")]
//        [AllowAnonymous]
//        public IActionResult IsAccountValid(string email)
//        {
//            var user = _hRSDBContext.Users.Where(u => u.Email == email).SingleOrDefault();
//            if (user != null)
//            {
//                return Json(true);
//            }
//            else
//            {
//                return Json($"This '{email}' has not a valid account.");
//            }
//        }
//        #endregion RemoteValidation

//        #region Authorized Hotel Access
//        public JsonResult HotelList(long userId)
//        {
//            var authorizationList = _hRSDBContext.Authorizations.Where(a => a.UserId == userId && a.HotelId != null).ToList();
//            var hotels = _hRSDBContext.Hotels.ToList();
//            var hotelAccessibleList = from a in authorizationList
//                                      join h in hotels
//                                      on a.HotelId equals h.Id
//                                      select new { a, h };
//            var list = new List<Hotels>();
//            foreach (var item in hotelAccessibleList)
//            {
//                var hotel = new Hotels()
//                {
//                    Id = item.h.Id,
//                    Name = item.h.Name
//                };
//                list.Add(hotel);
//            }
//            return Json(new SelectList(list, "Id", "Name"));
//        }

//        #endregion Authorized Hotel Access
//    }
//}