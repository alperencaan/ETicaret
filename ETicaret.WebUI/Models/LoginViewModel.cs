using System.ComponentModel.DataAnnotations;

namespace ETicaret.WebUI.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }// kullanıcı yönlendir
        public bool RememberMe { get; set; } // kullanıcıyı hatırla
    }
}
