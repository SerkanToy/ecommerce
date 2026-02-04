using ecommerce.api.Domain.DTOs.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ecommerce.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration configuration;
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            if (loginDto.UserName == "admin@admin.com" && loginDto.Password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginDto.UserName),
                    new Claim(ClaimTypes.Email, loginDto.UserName),
                    new Claim("FullName", "Admin ADMIN"),
                    new Claim("Invoice", "true")
                };

                var expiration = DateTime.UtcNow.AddMinutes(1);
                return Ok(new
                {
                    access_token = CreateToken(claims, expiration),
                    expiration = expiration
                });

            }
            ModelState.AddModelError("Unauthorized", "Kayıtlı Değilsiniz.");
            return Unauthorized(new LoginDto
            {
                UserName =  loginDto.UserName,
                Password = loginDto.Password,
                RememberMe = loginDto.RememberMe,
                Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
            });
        }

        private string CreateToken(List<Claim> claims, DateTime expiration)
        {
            var claimDic = new Dictionary<string, object>();
            if(claims is not null && claims.Count > 0)
            {
                foreach (var item in claims)
                {
                    claimDic.Add(item.Type, item.Value);
                }
            }
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["SecurityKey"] ?? string.Empty));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = claimDic,
                Expires = expiration,
                SigningCredentials = new SigningCredentials(
                    securityKey, 
                    SecurityAlgorithms.HmacSha256),
                NotBefore = DateTime.UtcNow
            };
            var tokenHandler = new JsonWebTokenHandler();
            return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}
