using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Trainings;

public class UpdateTrainingEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Training: Update")
            .WithSummary("Update a training")
            .WithDescription("Update a training")
            .WithOrder(2)
            .Produces<Response<Training?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITrainingHandler handler,
        UpdateTrainingRequest request,
        long id,
        long studentId,
        long instructorId)
    {
        request.User = user.Identity?.Name ?? string.Empty;
        request.Id = id;
        request.StudentId = studentId;
        request.InstructorId = instructorId;
            
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}