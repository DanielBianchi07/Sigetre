using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.CompanyPhone;

public class UpdateCompanyPhoneRequest
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Number { get; set; } = String.Empty;
}