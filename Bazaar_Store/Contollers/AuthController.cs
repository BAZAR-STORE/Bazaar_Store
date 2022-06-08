﻿using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Bazaar_Store.Models.Serviece;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Contollers
{
    public class AuthController : Controller
    {
        private IUserService _IdentityuserServices;
        public AuthController(IUserService userSer)
        {
            _IdentityuserServices = userSer;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> SignIn(RegisterUser register)
        {
            var user = await _IdentityuserServices.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> SignUp(RegisterUser register)
        {
            var user = await _IdentityuserServices.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }

        public async Task<ActionResult<UserDTO>> Authenticate(LoginDTO login)
        {
            var user = await _IdentityuserServices.Authenticate(login.UserName, login.Password);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return Redirect("/");
        }
    }
}