using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Specialization;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Specializations;

public class UpdateSpecializationEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Specialization: Update")
            .WithSummary("Update a specialization")
            .WithDescription("Update a specialization")
            .WithOrder(2)
            .Produces<Response<Specialization?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ISpecializationHandler handler,
        UpdateSpecializationRequest request,
        long id)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        }
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}