using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Alternative : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Content { get; set; } = String.Empty;

    public EAnswer Answer { get; set; }
    // relationship
    public long QuestionId { get; set; }
    public Question Question { get; set; }  = null!;
}