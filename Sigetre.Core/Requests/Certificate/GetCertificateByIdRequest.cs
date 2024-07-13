using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Certificate;

public class GetCertificateByIdRequest : PagedRequest
{
    [Required]
    public long Id { get; set; }
}