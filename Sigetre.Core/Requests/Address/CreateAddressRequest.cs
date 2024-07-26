using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class CreateAddressRequest : NullableRequest
{
    [Required]
    public string ZipCode { get; set; } = String.Empty;
    [Required]
    public string State { get; set; } = String.Empty;
    [Required]
    public string City { get; set; } = String.Empty;
    [Required]
    public string Neighborhood { get; set; } = String.Empty;
    [Required]
    public string StreetName { get; set; } = String.Empty;
    [Required]
    public string Number { get; set; } = String.Empty;
    public string? Complement { get; set; }
    public long? CompanyId { get; set; }
    
}