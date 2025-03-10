﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Student;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Students;

public class GetAllStudentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Students: Get All")
            .WithSummary("Show all students")
            .WithDescription("Show all students")
            .WithOrder(5)
            .Produces<PagedResponse<List<Student>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IStudentHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllStudentRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}