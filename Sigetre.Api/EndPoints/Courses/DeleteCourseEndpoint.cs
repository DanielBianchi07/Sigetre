﻿using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Courses;

public class DeleteCourseEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Course: Delete")
            .WithSummary("Delete a course")
            .WithDescription("Delete a course")
            .WithOrder(3)
            .Produces<Response<Course?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICourseHandler handler,
            long id)
        //long clientId)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new DeleteCourseRequest();
        if(clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}