using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class CreatePhoneRequest : NullableRequest
{
    [Required]
    public string Number { get; set; } = String.Empty;
    // relationship
    public long? CompanyId { get; set; }
}