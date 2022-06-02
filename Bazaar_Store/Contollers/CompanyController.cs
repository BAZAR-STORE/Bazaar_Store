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

        public IActionResult Index(string name,string description)
        {

            Company Companies = new Company {Name = name,Description = description };
            return View(Companies);
        }
       
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Company company)
        {
            if (ModelState.IsValid)
            {
                return Content("You have successfully added a company ! name: " + company.Name + " Description: " + company.Description);
            }
            return View(company);

        }
        public IActionResult Companies()
        {
            List<Company> company = new List<Company>();
            company.Add(new Company { Name = "Nike", Description = "dfjzvxjf" });
            company.Add(new Company { Name = "Pull&Bear", Description = "kldhfbzvxh" });
            company.Add(new Company { Name = "MSI", Description = ",mfdbvxjhds" });
            company.Add(new Company { Name = "K2", Description = "sdvzfdf" });
            company.Add(new Company { Name = "HP", Description = "khdbfv" });
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
       
        public IActionResult Delete()
        {

            return View();
        }
        [HttpDelete]
        public IActionResult Delete(Company company)
        {
            // get the object 
            // updating the object with the new data
            if (ModelState.IsValid)
            {
                return Content("You have successfully deleted data");
            }
            return View(company);
        }
    }
}
