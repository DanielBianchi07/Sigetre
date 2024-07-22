using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Instructors;

public class UpdateInstructorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Instructor: Update")
            .WithSummary("Update an instructor")
            .WithDescription("Update an instructor")
            .WithOrder(2)
            .Produces<Response<Instructor?>>();

    private static async Task<IResult> HandleAsync(
        IInstructorHandler handler,
        UpdateInstructorRequest request,
        long id)//, long clientId)
    {
        request.ClientId = 2;
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}