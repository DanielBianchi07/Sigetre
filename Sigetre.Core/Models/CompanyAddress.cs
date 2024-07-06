using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class CompanyAddress : BaseClass
{
    public long Id { get; set; }
    public string ZipCode { get; set; } = String.Empty;
    public string State { get; set; } = String.Empty;
    public string City { get; set; } = String.Empty;
    public string District { get; set; } = String.Empty;
    public string StreetName { get; set; } = String.Empty;
    public string Number { get; set; } = String.Empty;
    public string? Complement { get; set; }
}