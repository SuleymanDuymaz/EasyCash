using DTO.DTOS.AppUserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Ad alanı boş olamaz");
            RuleFor(p => p.SurName).NotEmpty().WithMessage("Soyad alanı boş olamaz");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullnıcı adı alanı boş olamaz");
            RuleFor(p => p.UserName).MinimumLength(6).WithMessage("Kullanıcı adı minumum  6 karakter olmalıdır");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");

        }
    }
}
