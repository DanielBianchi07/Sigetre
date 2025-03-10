﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Phones;

public class CreatePhoneEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Phone: Create")
            .WithSummary("Create a new phone number")
            .WithDescription("Create a new phone number")
            .WithOrder(1)
            .Produces<Response<Phone?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPhoneHandler handler,
            CreatePhoneRequest request)
    {
        request.User = user.Identity.Name;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}