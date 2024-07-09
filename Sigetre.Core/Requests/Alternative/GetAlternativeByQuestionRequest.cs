using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Alternative;

public class GetAlternativeByQuestionRequest : PagedRequest
{
    public long QuestionId { get; set; }
}