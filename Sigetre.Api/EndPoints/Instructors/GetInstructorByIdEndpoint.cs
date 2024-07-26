using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Instructors;

public class GetInstructorByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Instructors: Get By Id")
            .WithSummary("Show a instructor")
            .WithDescription("Show a instructor")
            .WithOrder(5)
            .Produces<Response<Instructor?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IInstructorHandler handler,
        long id)
    {
        var request = new GetInstructorByIdRequest()
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