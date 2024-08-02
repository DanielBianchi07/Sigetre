namespace Sigetre.Core.Models.Identity;

public class RoleClaim
{
    public string? Issuer { get; set; }
    public string? OrininalIssuer { get; set; }
    public string? Type { get; set; }
    public string? Value { get; set; }
    public string? ValueType { get; set; }
}