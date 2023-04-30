using CustomCookieBased.Data;
using CustomCookieBased.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomCookieBased.Controllers
{
    public class HomeController : Controller
    {
        private readonly CookieContext _context;

        public HomeController(CookieContext context)
        {
            _context = context;
        }

        public IActionResult SignIn()
        {
            return View(new UserSignInModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {

            var user = _context.Users.SingleOrDefault(x => x.UserRoles.Equals(model.Username) && x.Password.Equals(model.Password));

            if (user is not null)
            {
                var roles = _context.Roles.Where(x => x.UserRoles.Any(x => x.UserId == user.Id)).Select(x => x.Definition).ToList();

                var claims = new List<Claim>()
               {
                new Claim(ClaimTypes.Name,model.Username),
               };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Member")]
        public IActionResult Member()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
