using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Question;

public class GetQuestionByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}