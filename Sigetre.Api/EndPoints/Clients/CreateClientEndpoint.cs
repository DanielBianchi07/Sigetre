using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Client;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Clients;

public class CreateClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Client: Create")
            .WithSummary("Create a new client")
            .WithDescription("Create a new client")
            .WithOrder(1)
            .Produces<Response<Client?>>();

    private static async Task<IResult> HandleAsync(
            IClientHandler handler,
            CreateClientRequest request)
        //long clientId)
    {
        request.ClientId = 2;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}