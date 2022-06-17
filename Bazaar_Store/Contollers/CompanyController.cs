using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Contollers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        public async Task<IActionResult> Index()
        {

           List< Company> Companies = await _company.GetCompanies();
            return View(Companies);
        }
       
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Company company)
        {
            if (ModelState.IsValid)
            {
                var newCategory = await _company.Create(company);
                return RedirectToAction("Index");
            }
            return View(company);

        }
        public IActionResult Companies()
        {
            List<Company> company = new List<Company>();
            return View(company);
        }
        public IActionResult Update(/*id*/)    // What about the Id ?!
        {
            // retrieve the item from the database and pass it to the view
            Company company = new Company { Name = "added product", Description = "Update " };
            return View(company);
        }

        [HttpPost]
        public IActionResult Update(Company company)
        {
            // get the object 
            // updating the object with the new data
            if (ModelState.IsValid)
            {
                return Content("You have successfully edited data");
            }
            return View(company);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _company.GetCompanies();
            return Ok(companies);
        }

        public async Task<IActionResult> Delete(int Id)
        {

            var company = await _company.GetCompany(Id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
       
    }
}
