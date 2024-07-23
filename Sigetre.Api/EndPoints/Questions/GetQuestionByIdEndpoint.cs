using System.Security.Claims;
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
        ClaimsPrincipal user,
        IQuestionHandler handler,
        long id)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetQuestionByIdRequest();
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