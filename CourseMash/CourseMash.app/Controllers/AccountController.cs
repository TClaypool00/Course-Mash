using CourseMash.app.App_Code.BLL;
using CourseMash.app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseMash.app.Controllers
{
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
        public async Task<ActionResult> LoginAsync(LoginViewModel model)
        {
            try
            {
                if (!await _userService.UserExistsByEmailAsync(model.Email))
                {
                    ModelState.AddModelError("Email", "Email address invalid");
                }

                var user = await _userService.GetUserByEmailAsync(model.Email);

                if (!_bCryptService.VerifyPassword(model.Password, user.Password))
                {
                    ModelState.AddModelError("Password", "Invalid Password");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                } else
                {
                    return RedirectToAction("Index", "Home");
                }
            } catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View(model);
            }
        }
    }
}
