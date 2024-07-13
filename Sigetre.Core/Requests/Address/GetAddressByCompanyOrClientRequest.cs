using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class GetAddressByCompanyOrClientRequest : Request
{
    [Required]
    public long CompanyOrClientId { get; set; }
}