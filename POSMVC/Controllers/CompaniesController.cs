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
using POSMVC.Models;
using POSMVC.Models.Entities;
using POSMVC.Models.PageModels.CompaniesVM;

namespace POSMVC.Controllers
{
    public class CompaniesController : Controller
    {

        private readonly EyePosDBContext _context;
        private readonly IMapper _mapper;
        private readonly CommonFunctions _cmnFunction;
        private readonly IHostingEnvironment _he;

        public CompaniesController(
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
        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Company.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            var companyDetails = _context.Company.FirstOrDefault();
            var model = new CompanyDetails() {
                Company = companyDetails
            };
            return View(model);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(CompanyDetails com)
        {
            var result = (dynamic)null;
            try
            {

                var existCompany = _context.Company.Where(c => c.Id == com.Company.Id).FirstOrDefault();
                com.Company.BigLogo = existCompany.BigLogo;
                com.Company.SmallLogo = existCompany.SmallLogo;


                if (com.Company.Id > 0)
                {

                    //Image update...
                    if (com.ActualCompanyLogo != null) 
                    {
                        if (!string.IsNullOrEmpty(existCompany.BigLogo) && !string.IsNullOrEmpty(existCompany.SmallLogo))
                        {
                            _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existCompany.BigLogo));
                            _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existCompany.SmallLogo));
                        }

                        string extension = Path.GetExtension(com.ActualCompanyLogo.FileName);
                        string smallImage = "StaticFiles/Company/SmallImage/";
                        string bigImage = "StaticFiles/Company/BigImage/";

                        if (_cmnFunction.SaveImage(com.ActualCompanyLogo, com.Company.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
                        {
                            com.Company.SmallLogo = smallImage + com.Company.Id.ToString() + extension;
                        }

                        if (_cmnFunction.SaveImage(com.ActualCompanyLogo, com.Company.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
                        {
                            com.Company.BigLogo = bigImage + com.Company.Id.ToString() + extension;
                        }

                    }
                    //Image Clear...
                    if (com.ImageClearActive == true) {
                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existCompany.BigLogo));
                        _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existCompany.SmallLogo));

                        com.Company.BigLogo = "";
                        com.Company.SmallLogo = "";
                    }

                    //existCompany = com.Company;
                    _context.Entry(existCompany).CurrentValues.SetValues(com.Company);
                    await _context.SaveChangesAsync();

                    //existCompany = com.Company;
                    //_context.Entry(existCompany).State = EntityState.Modified;
                    //await _context.SaveChangesAsync();

                    return result = Json(new { success = true, message = "Data successfully updated.", redirectUrl = "/Companies/Create" });
                }
                else {
                    //Create New
                    var newCompany = com.Company;
                    _context.Company.Add(newCompany);
                    await _context.SaveChangesAsync();

                    string extension = Path.GetExtension(com.ActualCompanyLogo.FileName);
                    string smallImage = "StaticFiles/Company/SmallImage/";
                    string bigImage = "StaticFiles/Company/BigImage/";

                    if (_cmnFunction.SaveImage(com.ActualCompanyLogo, newCompany.Id.ToString(), Path.Combine(_he.WebRootPath, smallImage), extension, 60, 60))
                    {
                        newCompany.SmallLogo = smallImage + newCompany.Id.ToString() + extension;
                    }

                    if (_cmnFunction.SaveImage(com.ActualCompanyLogo, newCompany.Id.ToString(), Path.Combine(_he.WebRootPath, bigImage), extension))
                    {
                        newCompany.BigLogo = bigImage + newCompany.Id.ToString() + extension;
                    }
                    _context.Company.Add(newCompany);
                    await _context.SaveChangesAsync();
                    return result = Json(new { success = true, message = "Data successfully Saved.", redirectUrl = "/Companies/Create" });
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                result = Json(new { success = false, message = "Failed to save data.", redirectUrl = "" });
            }
            return result;
        }

        [HttpPost]
        public async Task<JsonResult> DeleteLogo(Company model)
        {
            var result = (dynamic)null;
            try
            {
                var existCompany = _context.Company.Where(c => c.Id == model.Id).FirstOrDefault();
                if (!string.IsNullOrEmpty(existCompany.BigLogo) && !string.IsNullOrEmpty(existCompany.SmallLogo))
                {
                    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existCompany.BigLogo));
                    _cmnFunction.DeleteStaticFile(Path.Combine(_he.WebRootPath, existCompany.SmallLogo));

                    existCompany.BigLogo = "";
                    existCompany.SmallLogo = "";
                    _context.Entry(model).CurrentValues.SetValues(existCompany);                   
                    await _context.SaveChangesAsync();
                }
                result = Json(new { success = true, message = "Logo successfully removed.", redirectUrl = @"/Companies/Create" });
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                result = Json(new { success = false, message = "Failed to remove logo.", redirectUrl = "" });
            }
            return result;
        }


        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Branch,Description,Address,Telephone,Mobile,Fax,Website,LogoPath,RegistrationNo")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
    }
}
