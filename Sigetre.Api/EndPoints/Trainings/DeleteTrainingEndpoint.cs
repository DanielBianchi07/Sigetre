using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Trainings;

public class DeleteTrainingEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Training: Delete")
            .WithSummary("Delete a training")
            .WithDescription("Delete a training")
            .WithOrder(3)
            .Produces<Response<Training?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITrainingHandler handler,
        long id)
    {
        var request = new DeleteTrainingRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}