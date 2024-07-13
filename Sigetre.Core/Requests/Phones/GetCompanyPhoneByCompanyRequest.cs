using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.CompanyPhone;

public class GetCompanyPhoneByCompanyRequest : PagedRequest
{
    [Required]
    public long CompanyId { get; set; }
}