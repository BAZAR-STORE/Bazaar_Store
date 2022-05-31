using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Contollers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        public async Task< IActionResult> Index()
        {

            var Categories = await _category.GetCategories();
            return View(Categories);
        }
        public async Task<IActionResult> GategoryDetail(int id)
        {
            var category = await _category.GetCategory(id);
            return View(category);
                }
    }
}
