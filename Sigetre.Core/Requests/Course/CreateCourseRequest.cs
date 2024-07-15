using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Course;

public class CreateCourseRequest : Request
{
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public int? InitialWorkload { get; set; }
    [Required]
    public int? PeriodicWorkload { get; set; }
    [Required]
    public int? Validity { get; set; }
    public Byte[]? Logo { get; set; }
    [Required]
    public long SpecializationId { get; set; }
}