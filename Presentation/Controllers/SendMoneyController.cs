using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class SendMoneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
