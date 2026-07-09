using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrbanMart.BuildingBlocks.Domain;
using UrbanMart.Modules.Identity.Application.Abstractions;
using UrbanMart.Modules.Identity.Infrastructure;
using UrbanMart.Modules.Identity.Persistence;

namespace UrbanMart.Modules.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityModule(this IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Postgres"),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.MigrationsHistoryTable(
                            "__identity_migrations_history", Schemas.Identity);
                    });
            });

            services.AddValidatorsFromAssembly(
                typeof(DependencyInjection).Assembly);

            services.AddScoped<
                Features.RegisterUser.Handler>();

            services.AddSingleton<
                IPasswordHasher,
                PasswordHasher>();

            services.AddSingleton<
                IIdentityNormalizer,
                IdentityNormalizer>();

            return services;
        }
    }
}