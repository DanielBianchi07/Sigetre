using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class GetPhoneByCompanyRequest : PagedRequest
{
    [Required]
    public long? CompanyId { get; set; }
    public new long? ClientId { get; set; }
}