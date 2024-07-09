using Microsoft.AspNetCore.Identity;

namespace Sigetre.Api.Models;

public class User : IdentityUser<long>
{
    // claims -> afirmação
    [PersonalData]
    public long ClientId { get; set; } //empresa referente
    [PersonalData]
    public string Name { get; set; } = string.Empty;
    
    public List<IdentityRole<long>>? Roles { get; set; }
}