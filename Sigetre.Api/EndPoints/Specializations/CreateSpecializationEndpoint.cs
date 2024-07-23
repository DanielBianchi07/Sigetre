using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Specialization;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Specializations;

public class CreateSpecializationEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Specialization: Create")
            .WithSummary("Create a new specialization")
            .WithDescription("Create a new specialization")
            .WithOrder(1)
            .Produces<Response<Specialization?>>();

    private static async Task<IResult> HandleAsync(
            ISpecializationHandler handler,
            CreateSpecializationRequest request)
        //long clientId)
    {
        request.ClientId = 2;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}