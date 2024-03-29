﻿using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable once IdentifierTypo
namespace BismillahGraphicsPro.Web.Controllers
{

    [Authorize]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRegistrationCore _registration;
        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IRegistrationCore registration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _registration = registration;
        }

        //GET: Login
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl=null)
        {
            if (returnUrl != null) ViewBag.ReturnUrl = returnUrl;

            if (User.Identity is { IsAuthenticated: true })
                return RedirectToAction("Index", "home");

            return View();
        }


        //POST: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl=null)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var type = _registration.UserTypeByUserName(model.UserName);

                if (type != UserType.Authority && !_registration.IsBranchActive(model.UserName))
                {
                    await _signInManager.SignOutAsync();
                    ModelState.AddModelError(string.Empty, "Branch is not activated");
                    return View(model);
                }
                if (type == UserType.SubAdmin && !_registration.IsSubAdminActive(model.UserName))
                {
                    await _signInManager.SignOutAsync();
                    ModelState.AddModelError(string.Empty, "Sub-Admin is deactivated by branch");
                    return View(model);
                }

                return type switch
                {
                    UserType.Admin => LocalRedirect(returnUrl ?? Url.Content($"/Admin")),
                    UserType.SubAdmin => LocalRedirect(returnUrl ?? Url.Content($"/Admin")),
                    UserType.Authority => LocalRedirect(returnUrl ?? Url.Content($"/Authority")),
                    _ => LocalRedirect(returnUrl ?? Url.Content($"/Authentication/Login"))
                };
            }

            if (result.RequiresTwoFactor) return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, model.RememberMe });

            if (result.IsLockedOut)
                return RedirectToPage("./Lockout");


            ModelState.AddModelError(string.Empty, "Incorrect username or password");
            return View(model);
        }


        // GET: ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
           
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await _signInManager.RefreshSignInAsync(user);

            await _registration.PasswordChangedAsync(user.UserName, model.NewPassword);

            return RedirectToAction("ChangePassword", "Authentication", new { Message = "Your password has been changed." });
        }

        //POST: logout
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null) return LocalRedirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        //access denied user
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
