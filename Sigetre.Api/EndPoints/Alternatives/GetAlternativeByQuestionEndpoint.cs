using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Alternative;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Alternatives;

public class GetAlternativeByQuestionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/question/{questionId}", HandleAsync)
            .WithName("Alternatives: Get By question")
            .WithSummary("Shows alternatives for a specif question")
            .WithDescription("Shows alternatives for a specif question")
            .WithOrder(5)
            .Produces<PagedResponse<List<Alternative>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IAlternativeHandler handler,
        long questionId, //long clientId,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new GetAlternativeByQuestionRequest();
        if(clientId != null & long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.QuestionId = questionId;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
        };
        var result = await handler.GetByQuestionAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}