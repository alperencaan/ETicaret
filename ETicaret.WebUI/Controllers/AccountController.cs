using Eticaret.Core.Entities;
using Eticaret.Data;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ETicaret.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly DatabaseContext _context;

        public AccountController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // işlemler
                }
                catch (Exception)
                {
                    ModelState.AddModelError(" ", "Hata Abicim");
                }
            }
            return View(loginViewModel);
        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(AppUser appUser)
        {
            appUser.IsAdmin = false; // Varsayılan olarak admin değil
            appUser.IsActive = true; // Varsayılan olarak aktif
            if (ModelState.IsValid)
            {
                await _context.AddAsync(appUser);  // AddAsync kullanın
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Eğer SignUp.cshtml varsa bunu dönmeniz daha mantıklı:
            return View("SignUp", appUser);
        }

    }
}
    
