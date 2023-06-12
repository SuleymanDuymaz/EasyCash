using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, true);
			if (result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(loginViewModel.Username);
				if (user.EmailConfirmed == true)
				{
					return RedirectToAction("Index", "MyAccounts");
				}
				
			}
			
			return View();
		}
	}
}
