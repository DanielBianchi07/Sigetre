using Microsoft.AspNetCore.Identity;
using Sigetre.Api.Common.Api;
using Sigetre.Api.Models;

namespace Sigetre.Api.EndPoints.Identity;

public class InscribeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/inscribe", HandleAsync)
            .WithName("Identity: inscribe")
            .WithSummary("Inscribe account")
            .WithDescription("Inscribe account");

    public static async Task<IResult> HandleAsync(RegisterModel model, UserManager<User> userManager)
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.PhoneNumber))
        {
            return Results.BadRequest("Todos os campos são obrigatórios.");
        }

        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            ClientId = model.ClientId
            // Mapeie outros campos conforme necessário
        };
    
        var result = await userManager.CreateAsync(user, model.Password);
    
        if (result.Succeeded)
        {
            return Results.Ok(user);
        }

        return Results.BadRequest(result.Errors);
    }
}