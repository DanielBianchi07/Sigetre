using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Addresses;

public class CreateAddressEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Address: Create")
            .WithSummary("Create a new address")
            .WithDescription("Create a new address")
            .WithOrder(1)
            .Produces<Response<Address?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IAddressHandler handler,
            CreateAddressRequest request)
    {
        request.User = user.Identity.Name;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}