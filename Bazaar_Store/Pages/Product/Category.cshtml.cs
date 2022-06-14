using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bazaar_Store.Pages.Product
{
    public class CategoryModel : PageModel
    {
        private ICategory CategoryServieces;

        [BindProperty]
        public List<Category> categories { get; set; }

        public CategoryModel(ICategory service)
        {
            CategoryServieces = service;
        }
        public async Task OnGetAsync()
        {
            categories = await CategoryServieces.GetCategories();
        }
    }
}
