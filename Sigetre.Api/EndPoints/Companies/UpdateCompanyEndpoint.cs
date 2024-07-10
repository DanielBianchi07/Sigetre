﻿using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Companies;

public class UpdateCompanyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Companies: Update")
            .WithSummary("Update a company")
            .WithDescription("Update a company")
            .WithOrder(2)
            .Produces<Response<Company?>>();

    private static async Task<IResult> HandleAsync(
        ICompanyHandler handler,
        UpdateCompanyRequest request,
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