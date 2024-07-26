using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Phones;

public class GetPhoneByClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/client/{clientId}", HandleAsync)
            .WithName("Phone: Get By Client")
            .WithSummary("Shows phone numbers from a specif client")
            .WithDescription("Shows phone numbers from a specif client")
            .WithOrder(5)
            .Produces<PagedResponse<List<Phone>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IPhoneHandler handler,
        long clientId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetPhoneByClientRequest();
        {
            request.User = user.Identity.Name;
            request.ClientId = clientId;
            request.CompanyId = null;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
        }
        var result = await handler.GetByClientAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}