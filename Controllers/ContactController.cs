using Microsoft.AspNetCore.Mvc;

namespace Kookis.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
