using CourseMash.app.App_Code.BLL;
using CourseMash.app.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CourseMash.app.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBCryptService _bCryptService;

        public AccountController(IUserService userService, IBCryptService bCryptService)
        {
            _userService = userService;
            _bCryptService = bCryptService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                if (await _userService.UserExistsByEmailAsync(model.Email))
                {
                    ModelState.AddModelError("Email", "Email address already exists");
                }

                if (await _userService.UserExistsByPhoneNumbAsync(model.PhoneNumb))
                {
                    ModelState.AddModelError("PhoneNumb", "Phone number already exists");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.Password = _bCryptService.HashPassword(model.Password);

                await _userService.AddUserAsync(model);

                TempData["Seccess"] = "Account has been created!";

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (TempData["Seccess"] is not null)
            {
                ViewBag.seccess = TempData["Seccess"];
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(LoginViewModel model)
        {
            try
            {
                if (!await _userService.UserExistsByEmailAsync(model.Email))
                {
                    ModelState.AddModelError("Email", "Invalid Email Address");
                }

                var user = await _userService.GetUserByEmailAsync(model.Email);

                if (!_bCryptService.VerifyPassword(model.Password, user.Password))
                {
                    ModelState.AddModelError("Password", "Invalid Password");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumb),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(1)
                };

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                return RedirectToAction("Index", "Home");

            } catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
