using Bazaar_Store.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
   public interface ICategory
    {
        Task<Category> Create(Category category);
        Task<List<CategoryDTO>> GetCategories();
        Task Delete(int Id);
        Task<CategoryDTO> GetCategory(int Id);
        Task<Category> UpdateCategory(int Id, Category category);
    }
}
