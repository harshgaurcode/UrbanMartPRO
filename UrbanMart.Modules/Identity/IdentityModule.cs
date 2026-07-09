using Microsoft.AspNetCore.Routing;

namespace UrbanMart.Modules.Identity
{
    public static class IdentityModule
    {
        public static IEndpointRouteBuilder MapIdentityModule(
       this IEndpointRouteBuilder app)
        {
            Features.RegisterUser.Endpoint.MapEndpoint(app);

            return app;
        }
    }
}