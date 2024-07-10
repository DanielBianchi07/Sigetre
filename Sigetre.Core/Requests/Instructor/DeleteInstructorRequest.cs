using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Instructor;

public class DeleteInstructorRequest : Request
{
    [Required]
    public long Id { get; set; }
}