using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce.dashboards.Pages.Blog
{
    [Authorize]
    public class BlogModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
