using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce.dashboards.Pages.Invoices
{
    [Authorize(Policy = "Invoice")]
    public class InvoiceCreateModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
