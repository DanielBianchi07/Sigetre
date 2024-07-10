using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Specialization;

public class DeleteSpecializationRequest : Request
{
    [Required]
    public long Id { get; set; }
}