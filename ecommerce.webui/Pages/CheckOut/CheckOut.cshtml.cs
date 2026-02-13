using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce.webui.Pages.CheckOut
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
