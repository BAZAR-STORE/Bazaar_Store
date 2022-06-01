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

            Company Categories = new Company {Name = name,Description = description };
            return View(Categories);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Company categories)
        {
            if (ModelState.IsValid)
            {
                return Content("You have successfully added a Category ! name: " + categories.Name + " Job: " + categories.Description);
            }
            return View(categories);

        }
        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Companies()
        {
            var companies = await _company.GetCompanies();
            return Ok(companies);
        }
    }
}
