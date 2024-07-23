using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.AttendanceList;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.AttendanceLists;

public class CreateAttendanceListEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("AttendanceList: Create")
            .WithSummary("Create a new attendance list")
            .WithDescription("Create a new attendance list")
            .WithOrder(1)
            .Produces<Response<AttendanceList?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IAttendanceListHandler handler,
            CreateAttendanceListRequest request)
        //long clientId)
    {
        var clientId = user.FindFirst("ClientId")?.Value;
        
        if(clientId != null && long.TryParse(clientId, out var clientIdClaim))
            request.ClientId = clientIdClaim;
        
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}