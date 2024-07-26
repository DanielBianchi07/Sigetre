using System.Security.Claims;
using Azure.Core;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Phones;

public class DeletePhoneEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Phone: Delete")
            .WithSummary("Delete a phone")
            .WithDescription("Delete a phone")
            .WithOrder(3)
            .Produces<Response<Phone?>>();

    private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPhoneHandler handler,
            long id)
    {
        var request = new DeletePhoneRequest()
        {
            User = user.Identity.Name,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}