namespace UrbanMart.Modules.Identity.Application.Abstractions
{
    public interface IIdentityNormalizer
    {
        string? NormalizeEmail(string? email);

        string? NormalizeMobileNumber(string? mobileNumber);
    }
}