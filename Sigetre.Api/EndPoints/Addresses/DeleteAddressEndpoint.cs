using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Addresses;

public class DeleteAddressEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Address: Delete")
            .WithSummary("Delete an address 'from' a company")
            .WithDescription("Delete an address 'from' a company")
            .WithOrder(3)
            .Produces<Response<Address?>>();

    private static async Task<IResult> HandleAsync(
            IAddressHandler handler,
            long id)
        //long clientId)
    {
        var request = new DeleteAddressRequest()
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