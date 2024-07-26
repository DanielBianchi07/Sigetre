namespace Sigetre.Core.Models.Birrelational;

public class Address : BaseNullableClass
{
    public long Id { get; set; }
    public string ZipCode { get; set; } = String.Empty;
    public string State { get; set; } = String.Empty;
    public string City { get; set; } = String.Empty;
    public string Neighborhood { get; set; } = String.Empty;
    public string StreetName { get; set; } = String.Empty;
    public string Number { get; set; } = String.Empty;
    public string? Complement { get; set; }
    
    public Company Company { get; set; } = null!;
    public Client Client { get; set; } = null!;

}