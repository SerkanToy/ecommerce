using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce.dashboards.Pages.Product
{
    [Authorize]
    public class ProductsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
