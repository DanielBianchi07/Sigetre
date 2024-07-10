using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Training;

public class DeleteTrainingRequest : Request
{
    [Required]
    public long Id { get; set; }
}