using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Requests.CompanyPhone;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ICompanyPhoneHandler
{
    Task<Response<Phones?>> CreateAsync(CreateCompanyRequest request);
    Task<Response<Phones?>> DeleteAsync(DeleteCompanyPhoneRequest request);
    Task<Response<Phones?>> UpdateAsync(UpdateCompanyPhoneRequest request);
    Task<PagedResponse<List<Phones>>> GetByCompanyAsync(GetCompanyPhoneByCompanyRequest request);
    Task<PagedResponse<List<Phones>>> GetAllAsync(GetAllCompanyPhoneRequest request);
}