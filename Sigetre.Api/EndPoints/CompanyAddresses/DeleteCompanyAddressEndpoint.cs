using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.CompanyAddress;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.CompanyAddresses;

public class DeleteCompanyAddressEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("CompanyAddresses: Delete")
            .WithSummary("Delete an address 'from' a company")
            .WithDescription("Delete an address 'from' a company")
            .WithOrder(3)
            .Produces<Response<CompanyAddress?>>();

    private static async Task<IResult> HandleAsync(
            ICompanyAddressHandler handler,
            long id)
        //long clientId)
    {
        var request = new DeleteCompanyAddressRequest()
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