using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Question;

public class UpdateQuestionRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Content { get; set; } = String.Empty;
    public long? CorrectAnswer { get; set; }
    [Required] 
    public long CourseId { get; set; }
}