﻿using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.CompanyAddress;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.CompanyAddresses;

public class GetCompanyAddressByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("CompanyAddresses: Get By Id")
            .WithSummary("Show an address from a company")
            .WithDescription("Show an address from a company")
            .WithOrder(4)
            .Produces<Response<CompanyAddress?>>();

    private static async Task<IResult> HandleAsync(
        ICompanyAddressHandler handler,
        long id)//, long clientId)
    {
        var request = new GetCompanyAddressByIdRequest()
        {
            ClientId = 2,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}