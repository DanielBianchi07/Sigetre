using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Specialization;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Specializations;

public class DeleteSpecializationEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Specialization: Delete")
            .WithSummary("Delete a specialization")
            .WithDescription("Delete a specialization")
            .WithOrder(3)
            .Produces<Response<Specialization?>>();

    private static async Task<IResult> HandleAsync(
            ISpecializationHandler handler,
            long id)
        //long clientId)
    {
        var request = new DeleteSpecializationRequest
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