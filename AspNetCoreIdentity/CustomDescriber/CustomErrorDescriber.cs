﻿using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.CustomDescriber
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new()
            {
                Code = "PasswordTooShor",
                Description = $"Parola en az {length} karakter olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new()
            {
                Code= "PasswordRequiresNonAlphanumeric",
                Description="Parola en az bir alfanümerik(!~ vs.) karakter içermelidir."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicateUserName",
                Description = $"{userName} zaten alınmış."
            };
        }
    }
}
