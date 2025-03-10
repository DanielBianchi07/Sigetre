using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Instructors;

public class GetAllInstructorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
                 => app.MapGet("/", HandleAsync)
                     .WithName("Instructors: Get All")
                     .WithSummary("Show all instructor")
                     .WithDescription("Show all instructor")
                     .WithOrder(4)
            .Produces<PagedResponse<List<Instructor>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IInstructorHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllInstructorRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}