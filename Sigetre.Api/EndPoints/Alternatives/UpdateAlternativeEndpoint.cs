﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Alternative;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Alternatives;

public class UpdateAlternativeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Alternatives: Update")
            .WithSummary("Update an alternative")
            .WithDescription("Update an alternative")
            .WithOrder(2)
            .Produces<Response<Alternative?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAlternativeHandler handler,
        UpdateAlternativeRequest request,
        long id)
    {
        request.User = user.Identity?.Name ?? string.Empty;
        request.Id = id;
     
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}