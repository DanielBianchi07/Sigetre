using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.ProgramContent;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.ProgramContents;

public class UpdateProgramContentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("ProgramContent: Update")
            .WithSummary("Update a program content")
            .WithDescription("Update a program content")
            .WithOrder(2)
            .Produces<Response<ProgramContent?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IProgramContentHandler handler,
        UpdateProgramContentRequest request,
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