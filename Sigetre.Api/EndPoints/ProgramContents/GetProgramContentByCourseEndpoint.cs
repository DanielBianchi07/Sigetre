﻿using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.ProgramContent;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.ProgramContents;

public class GetProgramContentByCourseEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/course/{courseId}", HandleAsync)
            .WithName("ProgramContent: Get By Course")
            .WithSummary("Shows program contents from a specif course")
            .WithDescription("Shows program contents from a specif course")
            .WithOrder(5)
            .Produces<PagedResponse<List<ProgramContent>?>>();

    private static async Task<IResult> HandleAsync(
        IProgramContentHandler handler,
        long specializationId, //long clientId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetProgramContentByCourseRequest()
        {
            ClientId = 2,
            CourseId = specializationId,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetByCourseAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}