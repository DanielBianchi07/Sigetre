using Microsoft.AspNetCore.Identity;
using Sigetre.Api.Common.Api;
using Sigetre.Api.Models;

namespace Sigetre.Api.EndPoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/logout", HandleAsync)
            .WithName("Identity: Logout")
            .WithSummary("Logout account")
            .WithDescription("Logout account")
            .RequireAuthorization();

    public static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}