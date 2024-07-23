using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class GetPhoneByClientRequest : PagedRequest
{
    [Required]
    public new long? ClientId { get; set; }
}