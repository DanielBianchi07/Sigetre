using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Courses;

public class UpdateCourseEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Course: Update")
            .WithSummary("Update a course")
            .WithDescription("Update a course")
            .WithOrder(2)
            .Produces<Response<Course?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICourseHandler handler,
        UpdateCourseRequest request,
        long id)//, long clientId)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        if(clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        };
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}