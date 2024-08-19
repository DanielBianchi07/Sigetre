using Microsoft.AspNetCore.Identity;
using Sigetre.Core.Models;

namespace Sigetre.Api.Models;

public class User : IdentityUser<long>
{
    // claims -> afirmação
    public List<IdentityRole<long>>? Roles { get; set; } = null!;
}