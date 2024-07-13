using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class GetAddressByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}