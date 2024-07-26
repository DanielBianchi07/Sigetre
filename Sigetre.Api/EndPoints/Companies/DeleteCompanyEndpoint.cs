using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Companies;

public class DeleteCompanyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Companies: Delete")
            .WithSummary("Delete a company")
            .WithDescription("Delete a company")
            .WithOrder(3)
            .Produces<Response<Company?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICompanyHandler handler,
            long id)
    {
        var request = new DeleteCompanyRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}