using Bazaar_Store.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate);
        Task<UserDto> Authenticate(string username, string password);
        Task<UserDto> GetUser(ClaimsPrincipal principal);
        Task Logout();
    }
}