using Bazaar_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Contollers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index(string name , string desciption)
        {
            Company category = new Company {Name = name,Desciption= desciption };
            return View(category);
        }public IActionResult Category()
        {
            Company category = new Company {Name = "baby", Desciption= "desciption " };
            return View(category);
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
                return Content("You have successfully added a company ! name: " + company.Name + " Desciption: " + company.Desciption);
            }
            return View(company);

        }
        public IActionResult List()
        {
            List<Company> company = new List<Company>();
            company.Add(new Company { Name = "fan", Desciption = "dfjzvxjf" });
            company.Add(new Company { Name = "laptop", Desciption = "kldhfbzvxh" });
            company.Add(new Company { Name = "keyboard", Desciption = ",mfdbvxjhds" });
            company.Add(new Company { Name = "headphone", Desciption = "sdvzfdf" });
            company.Add(new Company { Name = "mouse", Desciption = "khdbfv" });
            return View(company);
        }
        public IActionResult Update(/*id*/)    // What about the Id ?!
        {
            // retrieve the item from the database and pass it to the view
            Company company = new Company { Name = "added product", Desciption = "Update " };
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

    }
}
