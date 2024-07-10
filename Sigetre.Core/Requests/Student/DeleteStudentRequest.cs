using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Student;

public class DeleteStudentRequest : Request
{
    [Required]
    public long Id { get; set; }
}