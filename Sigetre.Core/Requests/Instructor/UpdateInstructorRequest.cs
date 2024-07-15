using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Instructor;

public class UpdateInstructorRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string Ssn { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    [Required]
    public string Registry { get; set; } = String.Empty;
    [Required]
    public string Telephone { get; set; } = String.Empty;
    public Byte[]? Signature { get; set; }
    // relationship
    [Required]
    public long SpecializationId { get; set; }
}