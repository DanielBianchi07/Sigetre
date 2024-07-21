using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Requests.Phones;

public class GetAllPhoneRequest : PagedRequest
{
    [Required] 
    public long CompanyId { get; set; }
}