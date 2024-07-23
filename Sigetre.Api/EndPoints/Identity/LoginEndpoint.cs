using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Sigetre.Api.Common.Api;
using Sigetre.Api.Models;

namespace Sigetre.Api.EndPoints.Identity;

public class LoginEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/log-in", HandleAsync)
            .WithName("Identity: log-in")
            .WithSummary("Log-in account")
            .WithDescription("Log-in account");

    public static async Task<IResult> HandleAsync(LoginRequest loginRequest, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        var user = await userManager.FindByEmailAsync(loginRequest.Email);
        if (user != null && await userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim("ClientId", user.ClientId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal);
            
            return Results.Ok(user);
        }

        return Results.BadRequest("Invalid Login attempt");
    }
}