using Bazaar_Store.Models;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazaar_Store.Contollers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult List()
        {
            List<Admin> Users = new List<Admin>();


            return View(Users);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegisterUser data)
        {
            try
            {
                var user = await _userService.Register(data, this.ModelState);
                if (ModelState.IsValid)
                {
                    return user;
                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
