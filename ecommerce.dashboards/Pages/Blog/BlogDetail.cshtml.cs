using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce.dashboards.Pages.Blog
{
    [Authorize]
    public class BlogDetailModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
