using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.CompanyAddress;

public class DeleteCompanyAddressRequest : Request
{
    [Required]
    public long Id { get; set; }
}