using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Test;

public class GetTestByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}