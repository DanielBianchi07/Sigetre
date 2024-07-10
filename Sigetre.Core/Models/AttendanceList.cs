using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class AttendanceList : BaseClass
{
    public long Id { get; set; }
    public string Code { get; set; } = String.Empty;
    public DateTime? TrainingStartedAt { get; set; }
    public Byte[]? Watermark { get; set; }
    public EDocumentSituation Situation { get; set; }
    
    public long TrainingId { get; set; }
    public Training Training { get; set; } = null!;
}