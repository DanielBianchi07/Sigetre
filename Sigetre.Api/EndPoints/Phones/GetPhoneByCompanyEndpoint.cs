﻿using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Phones;

public class GetPhoneByCompanyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/company/{companyId}", HandleAsync)
            .WithName("Phone: Get By Company")
            .WithSummary("Shows phone numbers from a specif company")
            .WithDescription("Shows phone numbers from a specif company")
            .WithOrder(5)
            .Produces<PagedResponse<List<Phone>?>>();

    private static async Task<IResult> HandleAsync(
        IPhoneHandler handler,
        long specializationId, //long clientId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetPhoneByCompanyRequest()
        {
            ClientId = 2,
            CompanyId = specializationId,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetByCompanyAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}