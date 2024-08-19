using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IAddressHandler
{
    Task<Response<Address?>> CreateAsync(CreateAddressRequest request);
    Task<Response<Address?>> DeleteAsync(DeleteAddressRequest request);
    Task<Response<Address?>> UpdateAsync(UpdateAddressRequest request);
    Task<Response<Address?>> GetByCompanyAsync(GetAddressByCompanyRequest request);
}