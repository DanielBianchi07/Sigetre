using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Client;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Clients;

public class GetClientByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Client: Get By Id")
            .WithSummary("Show a client")
            .WithDescription("Show a client")
            .WithOrder(5)
            .Produces<Response<Client?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IClientHandler handler,
        long id)//, long clientId)
    {
        var request = new GetClientByIdRequest()
        {
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}