using System.ComponentModel.DataAnnotations;

namespace ETicaret.WebUI.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress),Required(ErrorMessage ="Boş Alanlar Zorunludur..")] 
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password), Required(ErrorMessage = "Boş Alanlar Zorunludur..")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }// kullanıcı yönlendir
        public bool RememberMe { get; set; } // kullanıcıyı hatırla
    }
}
