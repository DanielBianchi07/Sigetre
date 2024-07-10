using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.ProgramContent;

public class DeleteProgramContentRequest : Request
{
    [Required]
    public long Id { get; set; }
}