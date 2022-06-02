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
            Company category = new Company {Name = name,Description= desciption };
            return View(category);
        }
    }
}
