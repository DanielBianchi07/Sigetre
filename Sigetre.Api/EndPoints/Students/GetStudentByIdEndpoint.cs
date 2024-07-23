﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Student;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Students;

public class GetStudentByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Student: Get By Id")
            .WithSummary("Show a student")
            .WithDescription("Show a student")
            .WithOrder(4)
            .Produces<Response<Student?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IStudentHandler handler,
        long id)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetStudentByIdRequest();
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        }
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}