using Microsoft.AspNetCore.Identity;

namespace Sigetre.Api.Models;

public class User : IdentityUser<long>
{
    // claims -> afirmação
    public List<IdentityRole<long>>? Roles { get; set; }
    public string Name { get; set; } = string.Empty;
    public long ClientId { get; set; } //empresa referente
    public bool IsAdmin { get; set; }
}