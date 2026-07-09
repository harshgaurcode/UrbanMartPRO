using Microsoft.AspNetCore.Identity;
using UrbanMart.Modules.Identity.Application.Abstractions;

namespace UrbanMart.Modules.Identity.Infrastructure
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private readonly Microsoft.AspNetCore.Identity.PasswordHasher<object> _passwordHasher =
        new();

        public string Hash(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool Verify(string password, string passwordHash)
        {
            var result = _passwordHasher.VerifyHashedPassword(
                null,
                passwordHash,
                password);

            return result == PasswordVerificationResult.Success ||
                   result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}