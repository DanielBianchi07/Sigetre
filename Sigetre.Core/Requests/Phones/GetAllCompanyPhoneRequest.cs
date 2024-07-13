using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.CompanyPhone;

public class GetAllCompanyPhoneRequest
{
    [Required] 
    public long CompanyId { get; set; }
}