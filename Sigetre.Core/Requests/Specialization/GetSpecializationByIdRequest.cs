using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Specialization;

public class GetSpecializationByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}