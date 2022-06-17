﻿using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class UserAdminServices : IUserAdmin
    {
        private UserManager<Admin> _userManager;
        private SignInManager<Admin> _signInManager;
        public UserAdminServices(UserManager<Admin> manager ,SignInManager<Admin> SignInMngr)
        {
            _userManager = manager;
            _signInManager = SignInMngr;
        }
        public async Task<UserAdminDto> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            // get the user from the user manager after successfully operating login
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new UserAdminDto
                {
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

           

            return null;
        }

        public async Task<UserAdminDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserAdminDto
            {
                Username = user.UserName
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserAdminDto> Register(RegisterUser data, ModelStateDictionary modelState)
        {
            var user = new Admin
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                IList<string> Roles = new List<string>();
                Roles.Add("administrator");
                await _userManager.AddToRolesAsync(user, Roles);
                UserAdminDto userDto = new UserAdminDto
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