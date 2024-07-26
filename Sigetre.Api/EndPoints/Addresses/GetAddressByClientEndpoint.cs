using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Addresses;

public class GetAddressByClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Address: Get By Client")
            .WithSummary("Show an address from a client")
            .WithDescription("Show an address from a client")
            .WithOrder(5)
            .Produces<Response<Address?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAddressHandler handler,
        long id)
    {
        var request = new GetAddressByClientRequest();
        
        request.User = user.Identity?.Name ?? string.Empty;
        var result = await handler.GetByClientAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}