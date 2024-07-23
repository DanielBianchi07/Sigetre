using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Specialization;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Specializations;

public class GetSpecializationByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Specialization: Get By Id")
            .WithSummary("Show a specialization")
            .WithDescription("Show a specialization")
            .WithOrder(4)
            .Produces<Response<Specialization?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ISpecializationHandler handler,
        long id)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetSpecializationByIdRequest();
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