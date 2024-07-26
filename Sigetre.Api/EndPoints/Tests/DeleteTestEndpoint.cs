using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Test;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Tests;

public class DeleteTestEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Test: Delete")
            .WithSummary("Delete a test")
            .WithDescription("Delete a test")
            .WithOrder(3)
            .Produces<Response<Test?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITestHandler handler,
        long id)
    {
        var request = new DeleteTestRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            Id = id,
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}