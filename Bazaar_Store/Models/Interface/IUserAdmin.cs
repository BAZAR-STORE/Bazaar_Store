using Bazaar_Store.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{

    public interface IUserAdmin
    {
        public Task<UserAdminDto> Register(RegisterUser data, ModelStateDictionary modelState);
        public Task<UserAdminDto> Authenticate(string username, string password);
        Task<UserAdminDto> GetUser(ClaimsPrincipal principal);

        public Task Logout();

    }
}

