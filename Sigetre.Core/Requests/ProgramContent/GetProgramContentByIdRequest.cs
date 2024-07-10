using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.ProgramContent;

public class GetProgramContentByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}