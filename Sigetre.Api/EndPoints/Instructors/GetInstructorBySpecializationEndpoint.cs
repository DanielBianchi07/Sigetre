using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Instructors;

public class GetInstructorBySpecializationEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/specialization/{specializationId}", HandleAsync)
            .WithName("Instructor: Get By Specialization")
            .WithSummary("Shows instructors for a specif specialization")
            .WithDescription("Shows instructors for a specif specialization")
            .WithOrder(5)
            .Produces<PagedResponse<List<Instructor>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IInstructorHandler handler,
        long specializationId, //long clientId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetInstructorBySpecialityRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            SpecialityId = specializationId,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetBySpecializationAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}