using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.AttendanceList;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.AttendanceLists;

public class DeleteAttendanceListEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("AttendanceList: Delete")
            .WithSummary("Delete an attendance list 'from' a training")
            .WithDescription("Delete an attendance list 'from' a training")
            .WithOrder(3)
            .Produces<Response<AttendanceList?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IAttendanceListHandler handler,
            long id)
        //long clientId)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        var request = new DeleteAttendanceListRequest();

        if (clientId != null && long.TryParse(clientId, out var clientIdClaim))
        {
            request.ClientId = clientIdClaim;
            request.Id = id;
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}