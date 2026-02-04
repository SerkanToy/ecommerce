using System.ComponentModel.DataAnnotations;

namespace ecommerce.api.Domain.DTOs.Account
{
    public class LoginDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
