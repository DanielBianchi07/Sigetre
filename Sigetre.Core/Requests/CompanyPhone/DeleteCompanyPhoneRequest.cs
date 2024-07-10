using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.CompanyPhone;

public class DeleteCompanyPhoneRequest : Request
{
    [Required] 
    public long Id { get; set; }
}