using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce.dashboards.Pages.Invoices
{
    [Authorize(Policy = "UserName")]
    public class InvoiceDetailModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
