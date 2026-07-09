using UrbanMart.Modules.Identity.Application.Abstractions;

namespace UrbanMart.Modules.Identity.Infrastructure
{
    public sealed class IdentityNormalizer : IIdentityNormalizer
    {
        public string? NormalizeEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            return email
                .Trim()
                .ToLowerInvariant();
        }

        public string? NormalizeMobileNumber(string? mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                return null;
            }

            return new string(
                mobileNumber
                    .Where(char.IsDigit)
                    .ToArray());
        }
    }
}