using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Company;

public class DeleteCompanyRequest : Request
{
    [Required]
    public long Id { get; set; }
}