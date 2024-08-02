using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Trainings;

public class GetTrainingByInstructorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/instructor/{instructorId}", HandleAsync)
            .WithName("Trainings: Get By Instructor")
            .WithSummary("Show all training By Instructor")
            .WithDescription("Show all training By Instructor")
            .WithOrder(8)
            .Produces<PagedResponse<List<Training>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITrainingHandler handler,
        long instructorId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetTrainingByInstructorRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            InstructorId = instructorId,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetByInstructorAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}