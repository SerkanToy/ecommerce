using ecommerce.dashboards.Model.Authorization;
using ecommerce.dashboards.Model.DTOs.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text.Json;

namespace ecommerce.dashboards.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDto LoginDto { get; set; }
        private IHttpClientFactory _httpClientFactory;

        public LoginModel(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }

        public void OnGet()
        {
            LoginDto = new LoginDto();
        }

        public async Task<IActionResult> OnPostLoginIn(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            JwtToken token = new JwtToken();
            var strTokenObj = HttpContext.Session.GetString("access_token");
            var client = _httpClientFactory.CreateClient("admin.ecommerce.api");
            if (String.IsNullOrEmpty(strTokenObj))
            {
                token = await GetTokenFromSessionOrApi(loginDto:loginDto, client: client);
            }
            else
            {
                token = JsonSerializer.Deserialize<JwtToken>(strTokenObj,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new JwtToken();
            }

            if (token == null || String.IsNullOrEmpty(token.AccessToken) || token.ExpireAt <= DateTime.UtcNow)


            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token?.AccessToken ?? string.Empty);

            if (loginDto.UserName == "admin@admin.com" && loginDto.Password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginDto.UserName),
                    new Claim(ClaimTypes.Email, loginDto.UserName),
                    new Claim("FullName", "Admin ADMIN"),
                    new Claim("invoice", "true"),
                    new Claim("admin", "true"),
                    new Claim("user", "true")
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


        private async Task<JwtToken> GetTokenFromSessionOrApi(LoginDto loginDto, HttpClient client)
        {

            var result = await client.PostAsJsonAsync("Auth/login", new LoginDto
            {
                UserName = loginDto.UserName,
                Password = loginDto.Password
            });
            result.EnsureSuccessStatusCode();
            var stringResult = await result.Content.ReadAsStringAsync();
            HttpContext.Session.SetString("access_token", stringResult);
            return JsonSerializer.Deserialize<JwtToken>(stringResult,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new JwtToken();
        }
           
    }
}
