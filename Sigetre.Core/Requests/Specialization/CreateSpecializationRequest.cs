using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Specialization;

public class CreateSpecializationRequest : Request
{
    [Required]
    public string Name { get; set; } = String.Empty;
}