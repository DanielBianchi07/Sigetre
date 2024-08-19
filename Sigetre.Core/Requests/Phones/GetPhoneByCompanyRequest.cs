using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class GetPhoneByCompanyRequest : PagedRequest
{
    public long CompanyId { get; set; }
}