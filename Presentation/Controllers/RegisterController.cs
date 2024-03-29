﻿using DTO.DTOS.AppUserDto;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace Presentation.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
		{
			if (ModelState.IsValid)
			{
				Random random = new Random();
				int code;
				code = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDto.UserName,
					Name = appUserRegisterDto.Name,
					Surname = appUserRegisterDto.SurName,
					Email = appUserRegisterDto.Email,
					City = "aaaa",//lat lonh
					District = "bbbb",
					ImageUrl = "cccc",
					ConfirmCode = code
				};
				var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
				if (result.Succeeded)
				{
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Kripto Yatırım Admin", "sduymaz8@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);

					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
					mimeMessage.Body = bodyBuilder.ToMessageBody();

					mimeMessage.Subject = "Kripto Yatırım Onay Kodu";

					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com", 587, false);
					client.Authenticate("sduymaz8@gmail.com", "atbhitqhhzrsruhq");
					client.Send(mimeMessage);
					client.Disconnect(true);



					TempData["Mail"] = appUserRegisterDto.Email;

					return RedirectToAction("Index", "ConfirmMail");
				}
                //asp - validation - summary alanı için

                else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View();
		}
	}
}
