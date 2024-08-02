using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Training;

public class GetTrainingByDateRequest : PagedRequest
{
    [Required] public DateTime Date { get; set; }
}