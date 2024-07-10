using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Student;

public class CreateStudentRequest : Request
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Ssn { get; set; } = string.Empty;
    public string Ic { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public Byte[]? Signature { get; set; }
}