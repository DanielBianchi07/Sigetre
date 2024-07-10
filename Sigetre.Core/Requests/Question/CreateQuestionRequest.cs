using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Question;

public class CreateQuestionRequest : Request
{
    [Required]
    public string Content { get; set; } = String.Empty;
    public long? CorrectAnswer { get; set; }
}