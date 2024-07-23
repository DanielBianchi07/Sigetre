using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Question;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Questions;

public class GetQuestionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Question: Get By Id")
            .WithSummary("Show a question")
            .WithDescription("Show a question")
            .WithOrder(4)
            .Produces<Response<Question?>>();

    private static async Task<IResult> HandleAsync(
        IQuestionHandler handler,
        long id)//, long clientId)
    {
        var request = new GetQuestionByIdRequest()
        {
            ClientId = 2,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}