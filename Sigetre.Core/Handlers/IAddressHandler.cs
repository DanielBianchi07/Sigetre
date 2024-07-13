using Sigetre.Core.Models;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IAddressHandler
{
    Task<Response<Addresses?>> CreateAsync(CreateAddressRequest request);
    Task<Response<Addresses?>> DeleteAsync(DeleteAddressRequest request);
    Task<Response<Addresses?>> UpdateAsync(UpdateAddressRequest request);
    Task<Response<Addresses?>> GetByIdAsync(GetAddressByIdRequest request);
    Task<PagedResponse<List<Addresses>>> GetByCompanyOrClientIdAsync(GetAddressByCompanyOrClientRequest request);
}