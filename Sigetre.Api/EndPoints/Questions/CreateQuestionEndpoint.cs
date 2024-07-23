using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Question;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Questions;

public class CreateQuestionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Question: Create")
            .WithSummary("Create a new question")
            .WithDescription("Create a new question")
            .WithOrder(1)
            .Produces<Response<Question?>>();

    private static async Task<IResult> HandleAsync(
            IQuestionHandler handler,
            CreateQuestionRequest request)
        //long clientId)
    {
        request.ClientId = 2;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}