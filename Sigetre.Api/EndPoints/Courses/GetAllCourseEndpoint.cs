using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Courses;

public class GetAllCourseEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Course: Get All")
            .WithSummary("Show all courses")
            .WithDescription("Show all courses")
            .WithOrder(4)
            .Produces<PagedResponse<List<Course>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICourseHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)//, long clientId)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetAllCourseRequest();
        if(clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
        };
        var result = await handler.GetAllCourseAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}