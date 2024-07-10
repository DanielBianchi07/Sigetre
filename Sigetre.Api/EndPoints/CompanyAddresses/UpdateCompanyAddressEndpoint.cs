using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.CompanyAddress;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.CompanyAddresses;

public class UpdateCompanyAddressEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("CompanyAddress: Update")
            .WithSummary("Update an address from a company")
            .WithDescription("Update an address from a company")
            .WithOrder(2)
            .Produces<Response<CompanyAddress?>>();

    private static async Task<IResult> HandleAsync(
        ICompanyAddressHandler handler,
        UpdateCompanyAddressRequest request,
        long id)//, long clientId)
    {
        request.ClientId = 2;
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}