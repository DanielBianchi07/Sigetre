using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Instructor;

public class GetInstructorByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}