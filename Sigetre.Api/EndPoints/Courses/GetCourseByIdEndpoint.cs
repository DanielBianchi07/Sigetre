using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Courses;

public class GetCourseByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Course: Get By Id")
            .WithSummary("Show a course")
            .WithDescription("Show a course")
            .WithOrder(5)
            .Produces<Response<Course?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICourseHandler handler,
        long id)
    {
        var request = new GetCourseByIdRequest()
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