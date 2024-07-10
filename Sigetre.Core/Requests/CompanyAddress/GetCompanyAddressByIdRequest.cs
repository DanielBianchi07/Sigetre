using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.CompanyAddress;

public class GetCompanyAddressByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}