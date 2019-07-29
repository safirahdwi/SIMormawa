using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace Ormawa.Controllers
{
    public class AccountController : AbstractBaseController
    {
        private const string Username = "test";
        private const string Password = "test";

        private const int UserId = 1;
        private const string Role = "admin";

        public IActionResult Login(string returnUrl)
        {
            return View(new ViewModels.LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ViewModels.LoginViewModel login)
        {
            if (login.Username != Username || login.Password != Password)
            {
                SetErrorNotification("Login error");
                return View(login);
            }

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, Username));
            claims.Add(new Claim(ClaimTypes.Role, Role));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var props = new AuthenticationProperties {IsPersistent = login.RememberMe};

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

            if (string.IsNullOrEmpty(login.ReturnUrl) || login.ReturnUrl == "/")
                return RedirectToAction("Index", "Default");
            else
                return Redirect(login.ReturnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
