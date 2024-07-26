using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Trainings;

public class GetTrainingByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Training: Get By Id")
            .WithSummary("Show a training")
            .WithDescription("Show a training")
            .WithOrder(4)
            .Produces<Response<Training?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITrainingHandler handler,
        long id)
    {
        var request = new GetTrainingByIdRequest()
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