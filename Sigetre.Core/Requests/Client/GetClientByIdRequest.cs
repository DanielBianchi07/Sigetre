using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Client;

public class GetClientByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}