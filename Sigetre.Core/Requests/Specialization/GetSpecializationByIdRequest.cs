using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Specialization;

public class GetSpecializationByIdRequest
{
    [Required]
    public long Id { get; set; }
}