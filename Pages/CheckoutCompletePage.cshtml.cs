using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kookis.Pages
{
    public class CheckoutCompletePageModel : PageModel
    {
        public void OnGet()
        {

            ViewData["CheckoutCompleteMessage"] = "Thanks for your order. you'll soon enjoy" +
                "our delicious pies!";
        }
    }
}
