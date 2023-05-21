using DTO.DTOS.AppUserDto;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(AppUserRegisterDto appUserRegisterDto)
        {

            return View();
        }
    }
}
