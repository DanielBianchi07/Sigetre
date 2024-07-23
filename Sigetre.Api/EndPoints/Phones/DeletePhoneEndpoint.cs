using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Phones;

public class DeletePhoneEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Phone: Delete")
            .WithSummary("Delete a phone")
            .WithDescription("Delete a phone")
            .WithOrder(3)
            .Produces<Response<Phone?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPhoneHandler handler,
            long id)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new DeletePhoneRequest();
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        }
        else
        {
            request.ClientId = null;
            request.Id = id;
        }
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}