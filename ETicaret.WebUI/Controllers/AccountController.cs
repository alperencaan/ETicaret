using Eticaret.Core.Entities;
using Eticaret.Data;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signin(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = await _context.AppUsers.FirstOrDefaultAsync(x => x.Email == loginViewModel.Email & x.Password == loginViewModel.Password & x.IsActive);
                    if (account == null)
                    {
                        ModelState.AddModelError(" ", "Kullanıcı bulunamadı");
                    }
                    else
                    {
                        var claims = new List<Claim>()
                        {
                            new(ClaimTypes.Name, account.Name),
                            new(ClaimTypes.Role, account.IsAdmin ? "Admin" : "Customer"),
                            new(ClaimTypes.Email, account.Email),
                            new("UserId", account.Id.ToString()),
                            new("UserGuid", account.UserGuid.ToString())

                    };
                        var userIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(userPrincipal);
                        return RedirectToAction("Index", "Home"); // Giriş başarılıysa anasayfaya yönlendir

                    }
                

                    // işlemler
                }
                catch (Exception hata)
                {
                    //loglama
                    ModelState.AddModelError(" ", "Hata Abicim");
                }
            }
            return View(loginViewModel);
        }


        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignupAsync(AppUser appUser)
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
            return View("Signup", appUser);
        }

    }
}

