using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class CreatePhoneRequest : Request
{
    [Required]
    public string Number { get; set; } = String.Empty;
    // relationship
    [Required]
    public long CompanyId { get; set; }
}