using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Courses;

public class CreateCourseEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Course: Create")
            .WithSummary("Create a new course")
            .WithDescription("Create a new course")
            .WithOrder(1)
            .Produces<Response<Course?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICourseHandler handler,
            CreateCourseRequest request)
    {
        request.User = user.Identity?.Name ?? string.Empty;
        
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}