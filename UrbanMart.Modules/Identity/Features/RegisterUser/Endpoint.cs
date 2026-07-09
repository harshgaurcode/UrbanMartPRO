using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UrbanMart.BuildingBlocks.Model.Enum;

namespace UrbanMart.Modules.Identity.Features.RegisterUser
{
    public static class Endpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(
                "/api/identity/customers/register",
                async (
                    Request request,
                    IValidator<Request> validator,
                    Handler handler,
                    CancellationToken cancellationToken) =>
                {
                    var validationResult = await validator.ValidateAsync(
                        request,
                        cancellationToken);

                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(
                            validationResult.ToDictionary());
                    }

                    var response = await handler.Handle(
                        request,
                        cancellationToken);

                    return response.Status switch
                    {
                        ResponseStatus.Success => Results.Ok(response),

                        ResponseStatus.Failed => Results.Conflict(response),

                        _ => Results.StatusCode(
                            StatusCodes.Status500InternalServerError)
                    };
                });
        }
    }
}