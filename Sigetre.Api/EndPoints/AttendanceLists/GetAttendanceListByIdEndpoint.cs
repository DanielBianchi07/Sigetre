﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.AttendanceList;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.AttendanceLists;

public class GetAttendanceListByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("AttendanceList: Get By Id")
            .WithSummary("Show an attendance list")
            .WithDescription("Show an attendance list")
            .WithOrder(5)
            .Produces<Response<AttendanceList?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAttendanceListHandler handler,
        long id)
    {
        var request = new GetAttendanceListByIdRequest()
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