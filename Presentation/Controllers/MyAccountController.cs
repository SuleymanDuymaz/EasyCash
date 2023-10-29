using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
	[Authorize]
	public class MyAccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
        public MyAccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDTO appUserEditDTO= new AppUserEditDTO();
           
			appUserEditDTO.Email= value.Email;


            return View(appUserEditDTO);
		}
        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDTO appUserEditDto)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.Surname = appUserEditDto.Surname;
                user.City = appUserEditDto.City;
                user.District = appUserEditDto.District;
                user.Name = appUserEditDto.Name;
                user.ImageUrl = "test";
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
