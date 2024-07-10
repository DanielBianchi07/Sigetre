using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Question;

public class DeleteQuestionRequest : Request
{
    [Required]
    public long Id { get; set; }
}