using Microsoft.AspNetCore.Mvc;
using Sigetre.Api.Common.Api;
using Sigetre.Core;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.AttendanceList;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.AttendanceLists;

public class GetAllAttendanceListEndoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("AttendanceList: Get All")
            .WithSummary("Show all attendance lists")
            .WithDescription("Show all attendance lists")
            .WithOrder(4)
            .Produces<PagedResponse<List<AttendanceList>?>>();

    private static async Task<IResult> HandleAsync(
        IAttendanceListHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)//, long clientId)
    {
        var request = new GetAllAttendanceListRequest
        {
            ClientId = 2,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}