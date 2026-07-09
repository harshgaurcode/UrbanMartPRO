using FluentValidation;

namespace UrbanMart.Modules.Identity.Features.RegisterUser
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must contain at least 8 characters.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email address is invalid.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.MobileNumber)
             .Matches(@"^\+?[0-9\s\-()]+$")
             .WithMessage("Mobile number format is invalid.")
             .MaximumLength(20)
             .WithMessage("Mobile number cannot exceed 20 characters.")
             .When(x => !string.IsNullOrWhiteSpace(x.MobileNumber));

            RuleFor(x => x)
                .Must(HaveEmailOrMobileNumber)
                .WithMessage("Either email or mobile number is required.");
        }

        private static bool HaveEmailOrMobileNumber(Request request)
        {
            return !string.IsNullOrWhiteSpace(request.Email)
                   || !string.IsNullOrWhiteSpace(request.MobileNumber);
        }
    }
}