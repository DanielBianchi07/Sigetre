using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Sigetre.Api.Models;

namespace Sigetre.Api.Common.Api;

public class AppUserClaimPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole<long>>
{
    public AppUserClaimPrincipalFactory(UserManager<User> userManager, 
        RoleManager<IdentityRole<long>> roleManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        
        identity.AddClaim(new Claim("UserFullName", user.Name ?? ""));
        identity.AddClaim(new Claim("UserEmail", user.Email ?? ""));
        identity.AddClaim(new Claim("UserPhoneNumber", user.PhoneNumber ?? ""));
        identity.AddClaim(new Claim("UserClientId", user.ClientId.ToString() ?? ""));
        
        return identity;
    }
}