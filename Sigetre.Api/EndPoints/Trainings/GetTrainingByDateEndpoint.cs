using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Trainings;

public class GetTrainingByDateEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/date/{date}", HandleAsync)
            .WithName("Trainings: Get By Date")
            .WithSummary("Show all training By Date")
            .WithDescription("Show all training By Date")
            .WithOrder(7)
            .Produces<PagedResponse<List<Training>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITrainingHandler handler,
        DateTime date,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetTrainingByDateRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            Date = date,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetByDateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}