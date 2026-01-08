using ecommerce.dashboards.Model.DTOs.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ecommerce.dashboards.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDto LoginDto { get; set; }

        public void OnGet()
        {
            LoginDto = new LoginDto();
        }

        public async Task<IActionResult> OnPostLoginIn(LoginDto loginDto) 
        { 
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if(loginDto.UserName == "admin@admin.com" && loginDto.Password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginDto.UserName),
                    new Claim(ClaimTypes.Email, loginDto.UserName),
                    new Claim("FullName", "Admin ADMIN"),
                    new Claim("Invoice", "true")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = loginDto.RememberMe });

                return RedirectToPage("/Index");
            }
            return Page();
        }

        [Authorize]
        public async Task<IActionResult> OnGetLogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("/Login");
        }
    }
}
