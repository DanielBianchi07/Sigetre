using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Question;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Questions;

public class GetQuestionByCourseEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/course/{courseId}", HandleAsync)
            .WithName("Question: Get By Course")
            .WithSummary("Shows questions from a specif course")
            .WithDescription("Shows questions from a specif course")
            .WithOrder(5)
            .Produces<PagedResponse<List<Question>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IQuestionHandler handler,
        long courseId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetQuestionByCourseRequest();
        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.CourseId = courseId;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
        }
        var result = await handler.GetByCourseAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}