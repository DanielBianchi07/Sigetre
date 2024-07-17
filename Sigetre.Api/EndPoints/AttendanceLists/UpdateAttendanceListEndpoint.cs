using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.AttendanceList;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.AttendanceLists;

public class UpdateAttendanceListEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("AttendanceList: Update")
            .WithSummary("Update an attendance list")
            .WithDescription("Update an attendance list")
            .WithOrder(2)
            .Produces<Response<AttendanceList?>>();

    private static async Task<IResult> HandleAsync(
        IAttendanceListHandler handler,
        UpdateAttendanceListRequest request,
        long id)//, long clientId)
    {
        request.ClientId = 2;
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}