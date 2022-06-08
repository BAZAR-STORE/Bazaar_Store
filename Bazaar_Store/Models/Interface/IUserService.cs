using Bazaar_Store.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{

    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(string username, string password);
        
    }
}

