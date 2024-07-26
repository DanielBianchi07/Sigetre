using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Companies;

public class GetCompanyByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Companies: Get By Id")
            .WithSummary("Show a company")
            .WithDescription("Show a company")
            .WithOrder(5)
            .Produces<Response<Company?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICompanyHandler handler,
        long id)
    {
        var request = new GetCompanyByIdRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}