using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Alternative;

public class DeleteAlternativeRequest : Request
{
    [Required]
    public long Id { get; set; }
}