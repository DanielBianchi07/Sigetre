using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests.Training;

public class CreateTrainingRequest : Request
{
    [Required]
    public ETrainingType Type { get; set; }
    [Required]
    public ETrainingSituation Situation { get; set; }
    // relationship
    [Required]
    public long CourseId { get; set; }
}