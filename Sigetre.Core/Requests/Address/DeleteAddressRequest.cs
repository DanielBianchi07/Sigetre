using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class DeleteAddressRequest : Request
{
    [Required]
    public long Id { get; set; }
}