using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Question;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Questions;

public class DeleteQuestionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Question: Delete")
            .WithSummary("Delete a question")
            .WithDescription("Delete a question")
            .WithOrder(3)
            .Produces<Response<Question?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IQuestionHandler handler,
        long id)
    {
        var request = new DeleteQuestionRequest()
        {
            User = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}