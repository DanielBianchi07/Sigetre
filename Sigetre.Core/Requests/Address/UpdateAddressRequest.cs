using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class UpdateAddressRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string ZipCode { get; set; } = String.Empty;
    public string State { get; set; } = String.Empty;
    public string City { get; set; } = String.Empty;
    public string District { get; set; } = String.Empty;
    public string StreetName { get; set; } = String.Empty;
    public string Number { get; set; } = String.Empty;
    public string? Complement { get; set; }
}