using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Address;

public class GetAddressByCompanyRequest : NullableRequest
{
    public long? CompanyId { get; set; }
}