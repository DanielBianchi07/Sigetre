using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests.AttendanceList;

public class CreateAttendanceListRequest : Request
{
    [Required]
    public string Code { get; set; } = String.Empty;
    [Required]
    public DateTime? TrainingStartedAt { get; set; }
    public Byte[]? Watermark { get; set; }
    [Required]
    public EDocumentSituation Situation { get; set; }
    [Required]
    public long TrainingId { get; set; }
}