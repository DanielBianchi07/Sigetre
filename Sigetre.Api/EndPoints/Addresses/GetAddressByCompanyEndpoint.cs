using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Addresses;

public class GetAddressByCompanyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Address: Get By Company")
            .WithSummary("Show an address from a company")
            .WithDescription("Show an address from a company")
            .WithOrder(4)
            .Produces<Response<Address?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAddressHandler handler,
        long id,
        long companyId)
    {
        var request = new GetAddressByCompanyRequest();
    
        request.User = user.Identity?.Name ?? string.Empty;
        request.CompanyId = companyId;
        var result = await handler.GetByCompanyAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}