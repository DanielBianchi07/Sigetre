using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Alternative;

public class GetAlternativeByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}