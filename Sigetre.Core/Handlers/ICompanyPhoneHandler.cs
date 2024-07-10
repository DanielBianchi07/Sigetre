using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Requests.CompanyPhone;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ICompanyPhoneHandler
{
    Task<Response<CompanyPhone?>> CreateAsync(CreateCompanyRequest request);
    Task<Response<CompanyPhone?>> DeleteAsync(DeleteCompanyPhoneRequest request);
    Task<Response<CompanyPhone?>> UpdateAsync(UpdateCompanyPhoneRequest request);
    Task<PagedResponse<List<CompanyPhone>>> GetByCompanyAsync(GetCompanyPhoneByCompanyRequest request);
    Task<PagedResponse<List<CompanyPhone>>> GetAllAsync(GetAllCompanyPhoneRequest request);
}