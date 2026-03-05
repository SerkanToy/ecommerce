using ecommerce.dashboards.Model.Authorization;
using ecommerce.dashboards.Model.DTOs;
using ecommerce.dashboards.Model.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ecommerce.dashboards.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private IHttpClientFactory _httpClientFactory;
        
        public List<DenemeClass>? denemeClassItems { get; set; }
        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGet()
        {
            var client = _httpClientFactory.CreateClient("admin.ecommerce.api");
            /*var result = await client.PostAsJsonAsync("Auth/login", new LoginDto
            {
                UserName = "admin@admin.com",
                Password = "admin"
            });
            result.EnsureSuccessStatusCode();
            var stringResult = await result.Content.ReadAsStringAsync();

            var token = JsonSerializer.Deserialize<JwtToken>(stringResult,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token?.AccessToken ?? string.Empty);*/

            denemeClassItems = await client.GetFromJsonAsync<List<DenemeClass>>("WeatherForecast") ?? new List<DenemeClass>();
        }
    }
}
