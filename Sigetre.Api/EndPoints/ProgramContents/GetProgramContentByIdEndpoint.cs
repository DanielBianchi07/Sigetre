using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.ProgramContent;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.ProgramContents;

public class GetProgramContentByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("ProgramContent: Get By Id")
            .WithSummary("Show a program content")
            .WithDescription("Show a program content")
            .WithOrder(4)
            .Produces<Response<ProgramContent?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IProgramContentHandler handler,
        long id)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetProgramContentByIdRequest();
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        }
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}