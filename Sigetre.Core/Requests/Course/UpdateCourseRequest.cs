using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Course;

public class UpdateCourseRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public int? InitialWorkload { get; set; }
    [Required]
    public int? PeriodicWorkload { get; set; }
    [Required]
    public int? Validity { get; set; }
    public Byte[]? Logo { get; set; }
}