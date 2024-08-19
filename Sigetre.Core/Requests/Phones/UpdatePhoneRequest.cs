using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class UpdatePhoneRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Number { get; set; } = String.Empty;
    public long CompanyId { get; set; }
}