using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Question;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Questions;

public class UpdateQuestionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Question: Update")
            .WithSummary("Update a question")
            .WithDescription("Update a question")
            .WithOrder(2)
            .Produces<Response<Question?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IQuestionHandler handler,
        UpdateQuestionRequest request,
        long id)
    {
        request.User = user.Identity?.Name ?? string.Empty;
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}