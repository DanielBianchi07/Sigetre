using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Training;

public class GetTrainingByStudentRequest : PagedRequest
{
    [Required] public long StudentId { get; set; }
}