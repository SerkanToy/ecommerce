using ecommerce.webui.Models.DTOs.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ecommerce.webui.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDto loginDto { get; set; }
        public void OnGet()
        {
            loginDto = new LoginDto();
        }

        public async Task<IActionResult> OnPostLogin(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Authentication logic would go here

            if(loginDto.UserName == "admin@admin.com" && loginDto.Password == "admin")
            {
                var claims = new List<Claim> { 
                    new Claim(ClaimTypes.Email, "admin@admin.com"),
                    new Claim(ClaimTypes.Name, "Admin")
                };

                var identity = new ClaimsIdentity(claims, "MyCookie");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookie",principal);

                return RedirectToPage("/Index");
            }

            return RedirectToPage("/Index");

        }


        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync("MyCookie");
            return RedirectToPage("/Login/login");

        }

    }
}
