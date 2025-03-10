using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Company;

public class GetCompanyByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}