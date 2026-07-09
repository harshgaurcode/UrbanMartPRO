using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UrbanMart.BuildingBlocks.Model.Enum;
using UrbanMart.Modules.Identity.Application.Abstractions;
using UrbanMart.Modules.Identity.Domain.Entities;
using UrbanMart.Modules.Identity.Domain.Enums;
using UrbanMart.Modules.Identity.Persistence;

namespace UrbanMart.Modules.Identity.Features.RegisterUser
{
    public class Handler
    {
        private readonly IdentityDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IIdentityNormalizer _normalizer;

        public Handler(IdentityDbContext identityContext, IPasswordHasher passwordHasher, IIdentityNormalizer normalizer)
        {
            _context = identityContext;
            _passwordHasher = passwordHasher;
            _normalizer = normalizer;
        }

        // only for Customer Login
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var normalizedEmail =
                _normalizer.NormalizeEmail(request.Email);

            var normalizedMobileNumber =
                _normalizer.NormalizeMobileNumber(request.MobileNumber);

            var emailExists =
                normalizedEmail is not null &&
                await _context.Users.AnyAsync(
                    user => user.Email == normalizedEmail,
                    cancellationToken);

            if (emailExists)
            {
                return new Response
                {
                    Status = ResponseStatus.Failed,
                    Message = "A user with this email already exists."
                };
            }

            var mobileExists =
                normalizedMobileNumber is not null &&
                await _context.Users.AnyAsync(
                    user => user.MobileNumber == normalizedMobileNumber,
                    cancellationToken);

            if (mobileExists)
            {
                return new Response
                {
                    Status = ResponseStatus.Failed,
                    Message = "A user with this mobile number already exists."
                };
            }

            var user = new User
            {
                Name = request.Name.Trim(),
                Email = normalizedEmail,
                MobileNumber = normalizedMobileNumber,
                PasswordHash = _passwordHasher.Hash(request.Password),
                Status = UserStatus.Active
            };

            user.UserRoles.Add(new UserRole
            {
                Role = UserRoleType.Customer,
                IsActive = true
            });

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return new Response
            {
                Status = ResponseStatus.Success,
                Message = "User registered successfully."
            };
        }
    }
}