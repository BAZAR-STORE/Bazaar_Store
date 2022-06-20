using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;
//using static Bazaar_Store.Pages.Accounts.LoginModel;
using static Bazaar_Store.Pages.Accounts.RegisterModel;

namespace Bazaar_Store.Models.Interface
{
    public interface IUser
    {
        public Task<User> Login(string username, string password);
        public Task<User> Register(RegisterData Input, ModelStateDictionary modelstate);
        Task<User> Create(User user);
        Task<List<User>> GetAll();
    }
}
