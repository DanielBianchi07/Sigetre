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
        IQuestionHandler handler,
        long specializationId, //long clientId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetQuestionByCourseRequest()
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