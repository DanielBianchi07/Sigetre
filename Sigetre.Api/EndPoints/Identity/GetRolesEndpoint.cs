using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Models.Identity;

namespace Sigetre.Api.EndPoints.Identity;

public class GetRolesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/roles", Handle)
            .WithName("Identity: roles")
            .WithSummary("Get roles")
            .WithDescription("Get roles")
            .RequireAuthorization();

    public static Task<IResult> Handle(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Task.FromResult(Results.Unauthorized());

        var identity = (ClaimsIdentity)user.Identity;
        var roles = identity.FindAll(identity.RoleClaimType).Select(c => new RoleClaim
        {
            Issuer = c.Issuer,
            OrininalIssuer = c.OriginalIssuer,
            Type = c.Type,
            Value = c.Value,
            ValueType = c.ValueType
        });
                
        return Task.FromResult<IResult>(TypedResults.Json(roles));
    }
}