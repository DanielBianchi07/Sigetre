using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Companies;

public class GetAllCompanyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Companies: Get All")
            .WithSummary("Show all companies")
            .WithDescription("Show all companies")
            .WithOrder(4)
            .Produces<PagedResponse<List<Company>?>>();

    private static async Task<IResult> HandleAsync(
        ICompanyHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)//, long clientId)
    {
        var request = new GetAllCompanyRequest
        {
            ClientId = 2,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}