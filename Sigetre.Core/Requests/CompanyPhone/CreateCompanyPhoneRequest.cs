using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.CompanyPhone;

public class CreateCompanyPhoneRequest : Request
{
    [Required]
    public string Number { get; set; } = String.Empty;
    // relationship
    [Required]
    public long CompanyId { get; set; }
}