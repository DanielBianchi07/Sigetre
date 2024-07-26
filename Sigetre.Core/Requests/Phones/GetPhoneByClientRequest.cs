using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class GetPhoneByClientRequest : PagedNullableRequest
{
    public long? CompanyId { get; set; }
}