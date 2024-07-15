using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Instructors;

public class DeleteInstructorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Instructor: Delete")
            .WithSummary("Delete a instructor")
            .WithDescription("Delete a instructor")
            .WithOrder(3)
            .Produces<Response<Instructor?>>();

    private static async Task<IResult> HandleAsync(
            IInstructorHandler handler,
            long id)
        //long clientId)
    {
        var request = new DeleteInstructorRequest
        {
            ClientId = 2,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}