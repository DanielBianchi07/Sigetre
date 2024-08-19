using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class GetAddressByCompanyRequest : Request
{
    public long CompanyId { get; set; }
}