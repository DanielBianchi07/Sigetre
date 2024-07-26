using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class GetPhoneByCompanyRequest : PagedNullableRequest
{
    public long? CompanyId { get; set; }
}