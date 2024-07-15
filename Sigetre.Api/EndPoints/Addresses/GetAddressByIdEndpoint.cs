using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Addresses;

public class GetAddressByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Address: Get By Id")
            .WithSummary("Show an address from a company")
            .WithDescription("Show an address from a company")
            .WithOrder(4)
            .Produces<Response<Address?>>();

    private static async Task<IResult> HandleAsync(
        IAddressHandler handler,
        long id)//, long clientId)
    {
        var request = new GetAddressByIdRequest()
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