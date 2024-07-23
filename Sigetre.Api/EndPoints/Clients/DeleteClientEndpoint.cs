using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Client;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Clients;

public class DeleteClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Client: Delete")
            .WithSummary("Delete a client")
            .WithDescription("Delete a client")
            .WithOrder(3)
            .Produces<Response<Client?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IClientHandler handler,
            long id)
        //long clientId)
    {
        var request = new DeleteClientRequest()
        {
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}