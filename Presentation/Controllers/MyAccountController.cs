﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	public class MyAccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
