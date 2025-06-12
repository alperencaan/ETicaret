using Microsoft.AspNetCore.Mvc;
using Eticaret.Core.Entities;
using Eticaret.Data;

namespace ETicaret.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _context;

        public AccountController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: /Account/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                // Aynı mail var mı?
                var existingUser = _context.AppUsers.FirstOrDefault(u => u.Email == appUser.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Bu e-posta zaten kayıtlı.");
                    return View(appUser);
                }

                _context.AppUsers.Add(appUser);
                _context.SaveChanges();
                return RedirectToAction("SignIn");
            }

            return View(appUser);
        }

        // GET: /Account/SignIn
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var user = _context.AppUsers.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("user", user.Name ?? user.Email);
                HttpContext.Session.SetString("isAdmin", user.IsAdmin.ToString() ?? "false");
                if(user.IsAdmin)
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "E-posta veya şifre yanlış.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
