using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Specialization;

public class UpdateSpecializationRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
}