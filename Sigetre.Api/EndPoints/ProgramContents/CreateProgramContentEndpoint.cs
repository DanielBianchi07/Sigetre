using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.ProgramContent;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.ProgramContents;

public class CreateProgramContentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("ProgramContent: Create")
            .WithSummary("Create a new program content number")
            .WithDescription("Create a new program content number")
            .WithOrder(1)
            .Produces<Response<ProgramContent?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IProgramContentHandler handler,
        CreateProgramContentRequest request)
    {
        var clientId = user.FindFirst("ClientId")?.Value;

        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
            request.ClientId = clientIdClaim;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}