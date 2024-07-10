using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.CompanyAddress;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.CompanyAddresses;

public class CreateCompanyAddressEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("CompanyAddresses: Create")
            .WithSummary("Create a new address")
            .WithDescription("Create a new address")
            .WithOrder(1)
            .Produces<Response<CompanyAddress?>>();

    private static async Task<IResult> HandleAsync(
            ICompanyAddressHandler handler,
            CreateCompanyAddressRequest request)
        //long clientId)
    {
        request.ClientId = 2;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}