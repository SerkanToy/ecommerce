using System.ComponentModel.DataAnnotations;

namespace ecommerce.dashboards.Model.DTOs.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-Posta veya Kullanıcı Adı Boş Olmaz.")]
        [EmailAddress(ErrorMessage = "E-Posta Giriniz..!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Boş Olmaz.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
