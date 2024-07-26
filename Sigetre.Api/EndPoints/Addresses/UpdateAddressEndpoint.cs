using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Addresses;

public class UpdateAddressEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("CompanyAddress: Update")
            .WithSummary("Update an address from a company")
            .WithDescription("Update an address from a company")
            .WithOrder(2)
            .Produces<Response<Address?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAddressHandler handler,
        UpdateAddressRequest request,
        long id)
    {
        request.User = user.Identity?.Name ?? string.Empty;
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}