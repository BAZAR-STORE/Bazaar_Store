using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bazaar_Store.Controllers
{
    [Authorize(Roles = "administrator,editor")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Auth");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto register)
        {
            if (register.UserName != null && register.Email != null && register.Password != null)
            {
                await _userService.Register(register, this.ModelState);
            }

            if (ModelState.IsValid)
            {
                return Redirect("/home/index");
            }

            return View();
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Index(LoginDto login)
        {
            if (login.Username != null && login.Password != null)
            {
                var user = await _userService.Authenticate(login.Username, login.Password);
                if(user != null)
                {
                    return Redirect("/home/index");
                }
                ModelState.AddModelError("NotMatch", "Username and Passowrd not match");
                return View();
            }
            return View();
        }
    }
}
