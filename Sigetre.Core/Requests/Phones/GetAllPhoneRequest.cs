using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Requests.Phones;

public class GetAllPhoneRequest : PagedRequest
{
    public long? CompanyId { get; set; }
    public new long? ClientId { get; set; }
}