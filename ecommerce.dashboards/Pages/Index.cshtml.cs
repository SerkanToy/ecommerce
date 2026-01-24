using ecommerce.dashboards.Model.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            denemeClassItems = await client.GetFromJsonAsync<List<DenemeClass>>("WeatherForecast") ?? new List<DenemeClass>();
        }
    }
}
