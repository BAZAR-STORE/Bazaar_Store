using Bazaar_Store.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface ICategory
    {
        Task<List<CategoryDTO>> GetCategories();

        Task<CategoryDTO> GetCategory(int Id);
    }
}
