using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int code)
        {
            return View();
        }
    }
}
