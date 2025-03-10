﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Alternative;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Alternatives;

public class DeleteAlternativeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Alternatives: Delete")
            .WithSummary("Delete an alternative")
            .WithDescription("Delete an alternative")
            .WithOrder(3)
            .Produces<Response<Alternative?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAlternativeHandler handler,
        long id)
    {
        var request = new DeleteAlternativeRequest()
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