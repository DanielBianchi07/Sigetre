using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Training;

public class GetTrainingByInstructorRequest : PagedRequest
{
    [Required] public long InstructorId { get; set; }
}