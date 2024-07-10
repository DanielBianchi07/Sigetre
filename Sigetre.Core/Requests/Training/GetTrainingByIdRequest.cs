using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Training;

public class GetTrainingByIdRequest : Request
{
    [Required] 
    public long Id { get; set; }
}