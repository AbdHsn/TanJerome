using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonLogics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using POSMVC.Models;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.HomeVM;

namespace POSMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly EyePosDBContext _context;
        private readonly CommonFunctions _cmnFunction;
        private readonly IHostingEnvironment _he;
        public HomeController(
            EyePosDBContext context,
            CommonFunctions cmnFunction,
            IHostingEnvironment he
            )
        {
            _context = context;
            _cmnFunction = cmnFunction;
            _he = he;
        }
        public IActionResult Index()
        {
            var lstProduct = new List<ListProduct>();
            //#region "Product List Segment: Start"
            //var products = from p in _context.Products
            //               join pi in _context.ProductImage on p.Id equals pi.ProductId
            //               join c in _context.Category on p.CategoryId equals c.Id
            //               join b in _context.Brand on p.BrandId equals b.Id
            //               select new
            //               {
            //                   product = p,
            //                   productImage = pi,
            //                   category = c,
            //                   brand = b
            //               };
            //foreach (var item in products)
            //{
            //    var product = new ListProduct()
            //    {
            //        Product = item.product,
            //        ProductImage = item.productImage,
            //        Category = item.category,
            //        Brand = item.brand
            //    };
            //    lstProduct.Add(product);
            //}
            //#endregion "Product List Segment: End"

            var model = new HomeVM() {
                ListProducts = lstProduct
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
