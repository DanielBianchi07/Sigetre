using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Phones;

public class GetAllPhoneEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Phones: Get All")
            .WithSummary("Show all phones")
            .WithDescription("Show all phones")
            .WithOrder(4)
            .Produces<PagedResponse<List<Phone>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IPhoneHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetAllPhoneRequest();
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
        }
        else
        {
            request.ClientId = null;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
        }
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}