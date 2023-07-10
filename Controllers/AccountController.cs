using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductCategory.Models;
using ProductCategory.ViewModels;

namespace ProductCategory.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> User { get; }
        public SignInManager<ApplicationUser> Sign { get; }
        public AccountController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> sign)
        {
            User = user;
            Sign = sign;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await User.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    //var pass = await User.CheckPasswordAsync(user, model.PassWord);
                    //if (pass)
                    //{
                    var result = await Sign.PasswordSignInAsync(user, model.PassWord, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        TempData["userId"] = user.Id;
                        return RedirectToAction(actionName: "Index", controllerName: "Dashboard");
                    }
                    ModelState.AddModelError("", "Password or email is invalid");
                    //}
                }
            }

            return View(model);
        }

        public IActionResult AddNewAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewAccount(UserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Address = newUser.Address,
                    Email = newUser.Email,
                    PhoneNumber = newUser.Phone,
                    UserName = newUser.Name,
                };

                var result = await User.CreateAsync(user, newUser.PassWord);
                if (result.Succeeded)
                {
                    return View("Login");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(newUser);
            }
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await Sign.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
