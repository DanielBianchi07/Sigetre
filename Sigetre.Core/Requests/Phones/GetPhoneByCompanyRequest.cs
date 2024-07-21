using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class GetPhoneByCompanyRequest : PagedRequest
{
    [Required]
    public long CompanyId { get; set; }
}