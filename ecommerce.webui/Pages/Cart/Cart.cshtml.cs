using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce.webui.Pages.Cart
{
    [Authorize]
    public class CartModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
