using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Company;

public class UpdateCompanyRequest : Request
{
    [Required]
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ein { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
}