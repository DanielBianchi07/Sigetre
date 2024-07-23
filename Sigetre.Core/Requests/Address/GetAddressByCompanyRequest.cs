using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class GetAddressByCompanyRequest : Request
{
    [Required]
    public long CompanyId { get; set; }
}