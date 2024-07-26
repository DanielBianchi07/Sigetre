using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class DeleteAddressRequest : NullableRequest
{
    [Required]
    public long Id { get; set; }
}