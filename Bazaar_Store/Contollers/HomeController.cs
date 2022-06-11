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
       
        public IActionResult Index( )
        {
            return View();
        }
    }
}
