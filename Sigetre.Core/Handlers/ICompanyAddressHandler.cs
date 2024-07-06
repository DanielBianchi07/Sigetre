using Sigetre.Core.Models;
using Sigetre.Core.Requests.CompanyAddress;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ICompanyAddressHandler
{
    Task<Response<CompanyAddress?>> CreateAsync(CreateCompanyAddressRequest request);
    Task<Response<CompanyAddress?>> DeleteAsync(DeleteCompanyAddressRequest request);
    Task<Response<CompanyAddress?>> UpdateAsync(UpdateCompanyAddressRequest request);
    Task<Response<CompanyAddress?>> GetByIdAsync(GetCompanyAddressByIdRequest request);
}