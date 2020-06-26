//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using CommonLogics;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using POSMVC.Models.Entities;
//using POSMVC.Models.PageModels.ProductsVM;
//using X.PagedList;

//namespace POSMVC.Controllers
//{
//    public class ProductsController : Controller
//    {
//        #region Global Variables
//        private readonly EyePosDBContext _context;
//        private readonly IMapper _mapper;
//        private readonly CommonFunctions _cmnFunction;
//        private readonly IHostingEnvironment _he;
//        #endregion

//        #region Constructor
//        public ProductsController(
//               EyePosDBContext context,
//               IMapper mapper,
//               CommonFunctions cmnFunction,
//               IHostingEnvironment he
//        )
//        {
//            _context = context;
//            _mapper = mapper;
//            _cmnFunction = cmnFunction;
//            _he = he;
//        }
//        #endregion

//        #region GetMethods
//        // GET: Products
//        public async Task<IActionResult> Index(int? page)
//        {
//            var pageNumber = page ?? 1;
//            int pageSize = 10;
//            //var products = _context.Products;//.ToPagedList(pageNumber, pageSize);
//            var products = from p in _context.Products
//                           join c in _context.Category on p.CategoryId equals c.Id
//                           join b in _context.Brand on p.BrandId equals b.Id
//                           join pi in _context.ProductImage on p.Id equals pi.ProductId
//                           into productAll
//                           from pa in productAll.DefaultIfEmpty()
//                           select new
//                           {
//                               product = p,
//                               category = c,
//                               brand = b,
//                               productImage = pa
//                           };
//            var lstProduct = new List<ListProduct>();
//            foreach (var item in products)
//            {
//                var product = new ListProduct()
//                {
//                    Product = item.product,
//                    ProductImage = item.productImage,
//                    Category = item.category,
//                    Brand = item.brand
//                };
//                lstProduct.Add(product);
//            }
//            var resultListProduct = lstProduct.ToPagedList(pageNumber, pageSize);


//            await Task.Run(() =>
//            {
//            });
//            return View(resultListProduct);
//            //  var eyePosDBContext = _context.Products.Include(p => p.Brand).Include(p => p.Category);
//            //  return View(await eyePosDBContext.ToListAsync());

//        }

//        // GET: Products/Create
//        public IActionResult Create()
//        {
//            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");
//            ViewData["CategoryId"] = new SelectList(_context.Category.Where(c => c.SubCategory == null), "Id", "ParentCategory");
//            return View();
//        }

//        // GET: Products/Edit/5
//        public async Task<IActionResult> Edit(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Products.FindAsync(id);
//            var productImage = _context.ProductImage.Where(pi => pi.ProductId == id).FirstOrDefault();
//            var updateProductDetails = new UpdateProduct()
//            {
//                Products = product,
//                ProductImage = productImage
//            };
//            if (updateProductDetails == null)
//            {
//                return NotFound();
//            }

//            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", updateProductDetails.Products.BrandId);
//            ViewData["CategoryId"] = new SelectList(_context.Category.Where(c => c.SubCategory == null), "Id", "ParentCategory", updateProductDetails.Products.CategoryId);
//            return View(updateProductDetails);
//        }

//        #endregion

//        #region PostMethods
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,ProductCode,Name,CategoryId,BrandId,Description,CostPrice,SellingPrice,MinSellingPrice,MemberPrice,WholesalePrice,IsActive,MetaTags,ProductImage")] CreateProduct product)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {

//                    var newProduct = _mapper.Map<Products>(product);
//                    _context.Products.Add(newProduct);
//                    await _context.SaveChangesAsync();
//                    if (newProduct.Id > 0)
//                    {
//                        var newProductImage = new ProductImage()
//                        {
//                            Title = product.ProductImage.FileName,
//                            ProductId = newProduct.Id
//                        };
//                        _context.ProductImage.Add(newProductImage);
//                        _context.SaveChanges();

//                        string extension = Path.GetExtension(product.ProductImage.FileName);
//                        string smallImage = "StaticFiles/ProductImage/SmallImage/";
//                        string bigImage = "StaticFiles/ProductImage/BigImage/";

//                        if (_cmnFunction.SaveImage(product.ProductImage, newProductImage.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
//                        {
//                            newProductImage.SmallImage = smallImage + newProductImage.Id.ToString() + extension;
//                        }

//                        if (_cmnFunction.SaveImage(product.ProductImage, newProductImage.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
//                        {
//                            newProductImage.BigImage = bigImage + newProductImage.Id.ToString() + extension;
//                        }
//                        _context.Entry(newProductImage).State = EntityState.Modified;
//                        await _context.SaveChangesAsync();
//                        return RedirectToAction(nameof(Index));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                string error = ex.ToString();
//            }

//            return View(product);
//        }

//        [HttpPost]
//        // [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(UpdateProduct updateProduct)
//        {
//            if (updateProduct.Products.Id <= 0)
//            {
//                return NotFound();
//            }
//            try
//            {
//                _context.Products.Update(updateProduct.Products);
//                await _context.SaveChangesAsync();


//                string smallImage = "StaticFiles/ProductImage/SmallImage/";
//                string bigImage = "StaticFiles/ProductImage/BigImage/";

//                var existProductImage = _context.ProductImage.Where(pi => pi.ProductId == updateProduct.Products.Id).FirstOrDefault();

//                if (existProductImage == null)
//                {
//                    //new proudct image creation.
//                    var newProductImage = new ProductImage()
//                    {
//                        Title = updateProduct.ProductActualImage.FileName,
//                        ProductId = updateProduct.Products.Id
//                    };
//                    _context.ProductImage.Add(newProductImage);
//                    _context.SaveChanges();

//                    string extension = Path.GetExtension(updateProduct.ProductActualImage.FileName);

//                    if (_cmnFunction.SaveImage(updateProduct.ProductActualImage, newProductImage.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
//                    {
//                        newProductImage.SmallImage = smallImage + newProductImage.Id.ToString() + extension;
//                    }

//                    if (_cmnFunction.SaveImage(updateProduct.ProductActualImage, newProductImage.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
//                    {
//                        newProductImage.BigImage = bigImage + newProductImage.Id.ToString() + extension;
//                    }
//                    _context.Entry(newProductImage).State = EntityState.Modified;
//                    await _context.SaveChangesAsync();
//                }

//                if (updateProduct.ProductImage.Id > 0)
//                {
//                    //if true, than product image already exist.
//                    if (updateProduct.ProductActualImage != null)
//                    {
//                        //Delete previous physical image and update image name with previous ProductImage Id with extension
//                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existProductImage.BigImage));
//                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existProductImage.SmallImage));

//                        string extension = Path.GetExtension(updateProduct.ProductActualImage.FileName);

//                        //Updating/Replacing product images after deleting old images
//                        if (_cmnFunction.SaveImage(updateProduct.ProductActualImage, existProductImage.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
//                        {
//                            existProductImage.SmallImage = smallImage + existProductImage.Id.ToString() + extension;
//                        }

//                        if (_cmnFunction.SaveImage(updateProduct.ProductActualImage, existProductImage.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
//                        {
//                            existProductImage.BigImage = bigImage + existProductImage.Id.ToString() + extension;

//                        }
//                        _context.Entry(existProductImage).State = EntityState.Modified;
//                        await _context.SaveChangesAsync();

//                    }
//                    if (updateProduct.ProductActualImage == null && updateProduct.ImageClearActive == true)
//                    {
//                        //Delete previous physical image and update image name with previous ProductImage Id with extension
//                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existProductImage.BigImage));
//                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existProductImage.SmallImage));

//                        //Delete productimage record also.
//                       // _context.ProductImage.Remove(existProductImage);
//                        await _context.SaveChangesAsync();
//                    }
//                }
//            }
//            catch (DbUpdateConcurrencyException ex)
//            {

//            }
//            return RedirectToAction(nameof(Index));

//        }

//        // POST: Products/Delete/5
//        [HttpPost, ActionName("Delete")]
//        //  [ValidateAntiForgeryToken]
//        public async Task<JsonResult> DeleteProduct(Products model)
//        {
//            var result = (dynamic)null;
//            try
//            {
//                //Get Product Image record from database
//                var productImage = await _context.ProductImage.Where(pi => pi.ProductId == model.Id).FirstOrDefaultAsync();
//                if (productImage != null)
//                {
//                    //Delete  physical image file
//                    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, productImage.BigImage));
//                    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, productImage.SmallImage));
                    
//                    //Delete productimage record from database.
//                    _context.ProductImage.Remove(productImage);
//                    await _context.SaveChangesAsync();
//                }

//                //Delete Product from database
//                var products = await _context.Products.FindAsync(model.Id);
//                _context.Products.Remove(products);
//                await _context.SaveChangesAsync();

//                result = Json(new { success = true, message = " successfully deleted", redirectUrl = "/Products" });
//            }
//            catch (Exception ex)
//            {
//                string error = ex.ToString();
//                result = Json(new { success = false, message = "Operation failed!", redirectUrl = "/Products" });
//            }
//            return result;
//        }

//        // DeleteImage
//        [HttpPost, ActionName("DeleteProductImage")]
//      //  [ValidateAntiForgeryToken]
//        public async Task<JsonResult> DeleteProductImage(Products model)
//        {
//            var result = (dynamic)null;
//            try
//            {
//                //Get Product Image record from database
//             //   var productImage = await _context.ProductImage.Where(pi => pi.ProductId == model.Id).FirstOrDefaultAsync();
//                if (productImage != null)
//                {
//                    //Delete  physical image file
//                    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, productImage.BigImage));
//                    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, productImage.SmallImage));

//                    //Delete productimage record from database.
//                 //   _context.ProductImage.Remove(productImage);
//                    await _context.SaveChangesAsync();
//                    result = Json(new { success = true, message = "Product Image successfully removed.", redirectUrl = @"/Products/Edit/" + model.Id });
//                }
//                else
//                    result = Json(new { success = false, message = "No product image available to delete", redirectUrl = @"/Products/Edit/" + model.Id });
//            }
//            catch (Exception ex)
//            {
//                string error = ex.ToString();
//                result = Json(new { success = false, message = "Failed to remove product image.", redirectUrl = "" });
//            }
//            return result;
//        }
//        #endregion
//    }
//}
