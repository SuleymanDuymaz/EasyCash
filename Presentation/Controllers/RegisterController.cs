using DTO.DTOS.AppUserDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.UserName,
                    Name = appUserRegisterDto.Name,
                    Surname=appUserRegisterDto.SurName,
                    Email = appUserRegisterDto.Email,

                };
                var result=await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","ConfirmMail");
                }
            }
            return View();
        }
    }
}
