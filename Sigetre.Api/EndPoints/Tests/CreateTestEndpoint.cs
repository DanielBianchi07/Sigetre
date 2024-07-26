using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Test;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Tests;

public class CreateTestEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Test: Create")
            .WithSummary("Create a new test")
            .WithDescription("Create a new test")
            .WithOrder(1)
            .Produces<Response<Test?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITestHandler handler,
        CreateTestRequest request)
    {
        request.User = user.Identity?.Name ?? string.Empty;

        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}