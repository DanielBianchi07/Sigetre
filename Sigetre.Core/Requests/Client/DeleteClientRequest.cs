using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Client;

public class DeleteClientRequest : Request
{
    [Required]
    public long Id { get; set; }   
}