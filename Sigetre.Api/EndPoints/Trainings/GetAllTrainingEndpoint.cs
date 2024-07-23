﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Trainings;

public class GetAllTrainingEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Trainings: Get All")
            .WithSummary("Show all training")
            .WithDescription("Show all training")
            .WithOrder(5)
            .Produces<PagedResponse<List<Training>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITrainingHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetAllTrainingRequest();
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
        }
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}