using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Instructors;

public class GetInstructorByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Instructors: Get By Id")
            .WithSummary("Show a instructor")
            .WithDescription("Show a instructor")
            .WithOrder(5)
            .Produces<Response<Instructor?>>();

    private static async Task<IResult> HandleAsync(
        IInstructorHandler handler,
        long id)//, long clientId)
    {
        var request = new GetInstructorByIdRequest()
        {
            ClientId = 2,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}