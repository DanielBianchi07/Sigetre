using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Client;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Clients;

public class GetAllClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Clients: Get All")
            .WithSummary("Show all clients")
            .WithDescription("Show all clients")
            .WithOrder(4)
            .Produces<PagedResponse<List<Client>?>>();

    private static async Task<IResult> HandleAsync(
        IClientHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)//, long clientId)
    {
        var request = new GetAllClientRequest
        {
            ClientId = 2,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}