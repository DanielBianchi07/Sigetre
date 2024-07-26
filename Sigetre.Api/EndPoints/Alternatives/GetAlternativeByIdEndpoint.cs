using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Alternative;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Alternatives;

public class GetAlternativeByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Alternatives: Get By Id")
            .WithSummary("Show an alternative")
            .WithDescription("Show an alternative")
            .WithOrder(4)
            .Produces<Response<Alternative?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAlternativeHandler handler,
        long id)
    {
        var request = new GetAlternativeByIdRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}