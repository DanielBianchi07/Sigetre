using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Certificate;

public class DeleteCertificateRequest : Request
{
    [Required]
    public long Id { get; set; }
}