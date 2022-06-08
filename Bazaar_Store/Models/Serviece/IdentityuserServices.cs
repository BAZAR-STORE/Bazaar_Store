using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class IdentityuserServices : IUserService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public IdentityuserServices(UserManager<User> manager ,SignInManager<User> SignInMngr)
        {
            _userManager = manager;
            _signInManager = SignInMngr;
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            // get the user from the user manager after successfully operating login
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new UserDTO
                {
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

           

            return null;
        }

      

        public async Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState)
        {
            var user = new User
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                IList<string> Roles = new List<string>();
                Roles.Add("user");
                await _userManager.AddToRolesAsync(user, Roles);
                UserDTO userDto = new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
                return userDto;

                
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }

    }
}
