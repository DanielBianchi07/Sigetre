﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Companies;

public class CreateCompanyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Companies: Create")
            .WithSummary("Create a new company")
            .WithDescription("Create a new company")
            .WithOrder(1)
            .Produces<Response<Company?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICompanyHandler handler,
            CreateCompanyRequest request)
    {
        request.User = user.Identity?.Name ?? string.Empty;

        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}