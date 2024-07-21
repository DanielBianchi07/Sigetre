using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Alternative;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Alternatives;

public class CreateAlternativeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Alternatives: Create")
            .WithSummary("Create a new alternative")
            .WithDescription("Create a new alternative")
            .WithOrder(1)
            .Produces<Response<Alternative?>>();

    private static async Task<IResult> HandleAsync(
            AppDbContext context,
            ClaimsPrincipal user,
        IAlternativeHandler handler,
        CreateAlternativeRequest request)
        //long clientId)
    {
        request.ClientId = 2;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}