using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Poultry_management_System.Models;

namespace Poultry_management_System.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPage(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                Console.WriteLine(user);
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        public IActionResult LoginPage(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                Console.WriteLine(result);

                if (result.Succeeded)
                {

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutPage()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LoginPage", "Accounts");
        }


        //[HttpPost]
        //public async Task<IActionResult> LoginPage(LoginViewModel model, string? returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

        //            if (result.Succeeded)
        //            {
        //                // IMPORTANT: Prevent open redirect attack
        //                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        //                {
        //                    return Redirect(returnUrl);
        //                }
        //                else
        //                {
        //                    return RedirectToAction("Index", "CaptureEntry");
        //                }
        //            }
        //        }

        //        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> LoginPage(LoginViewModel model, string? returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
        //            if (result.Succeeded)
        //                return Redirect(returnUrl ?? "/CaptureEntry");
        //        }
        //        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //        //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

        //        //if (result.Succeeded)
        //        //{
        //        //    return RedirectToAction("Index", "CaptureEntry");
        //        //}
        //        //else
        //        //{
        //        //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //        //    return View(model);
        //        //}
        //    }
        //    return View(model);
        //}

    }
}
