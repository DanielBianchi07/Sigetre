using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Test;

public class DeleteTestRequest : Request
{
    [Required]
    public long Id { get; set; }
}