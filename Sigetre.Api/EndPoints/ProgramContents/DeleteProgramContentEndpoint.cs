using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.ProgramContent;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.ProgramContents;

public class DeleteProgramContentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("ProgramContent: Delete")
            .WithSummary("Delete a program content")
            .WithDescription("Delete a program content")
            .WithOrder(3)
            .Produces<Response<ProgramContent?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IProgramContentHandler handler,
        long id)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new DeleteProgramContentRequest();
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        }
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}