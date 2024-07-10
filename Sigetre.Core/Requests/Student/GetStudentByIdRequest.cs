using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Student;

public class GetStudentByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}