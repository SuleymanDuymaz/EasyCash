using Microsoft.AspNetCore.Identity;

namespace Presentation.Models
{
    public class CustomerIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır!"
            };
            // return base.PasswordTooShort(6);
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code= "PasswordRequiresDigit",
                Description=$"Parola sayısal bir değer içermelidir"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code= "PasswordRequiresLower",
                Description=$"Parola küçük karakter içermelidir"
                
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code= "PasswordRequiresNonAlphanumeric",
                Description= $"Parola bir semböl içermeliir"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code= "PasswordRequiresUpper",
                Description=$""
            };
        }
         

    }
}
