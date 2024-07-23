using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Test;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Tests;

public class UpdateTestEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Test: Update")
            .WithSummary("Update a test")
            .WithDescription("Update a test")
            .WithOrder(2)
            .Produces<Response<Test?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITestHandler handler,
        UpdateTestRequest request,
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