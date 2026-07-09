namespace UrbanMart.Modules.Identity.Features.RegisterUser
{
    public sealed class Request
    {
        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Password { get; set; } = string.Empty;

        public string? MobileNumber { get; set; }
    }
}