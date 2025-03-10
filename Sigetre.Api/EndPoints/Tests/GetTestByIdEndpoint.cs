﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Test;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Tests;

public class GetTestByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Test: Get By Id")
            .WithSummary("Show a test")
            .WithDescription("Show a test")
            .WithOrder(4)
            .Produces<Response<Test?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITestHandler handler,
        long id)
    {
        var request = new GetTestByIdRequest()
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