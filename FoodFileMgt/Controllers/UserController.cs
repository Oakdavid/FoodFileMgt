using FoodFileMgt.Dtos;
using FoodFileMgt.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodFileMgt.Controllers
{
    public class UserController : Controller
    {
        private readonly ILoginService _loginService;
        public UserController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequestModel model)
        {
            var user = await _loginService.Login(model);
            if(!user.Status)
            {
                return View(model);
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Data.Id),
                new Claim(ClaimTypes.Name, user.Data.FullName),
                new Claim(ClaimTypes.Email, user.Data.Email),
                new Claim("Image", user.Data.ImageUrl)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, properties);
            if(user.Data.RoleName == "SuperAdmin")
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
            
        }
    }
}
