using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	public class ConfirmMailController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
