using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Phones;

public class UpdatePhoneEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Phone: Update")
            .WithSummary("Update a phone number")
            .WithDescription("Update a phone number")
            .WithOrder(2)
            .Produces<Response<Phone?>>();

    private static async Task<IResult> HandleAsync(
        IPhoneHandler handler,
        UpdatePhoneRequest request,
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