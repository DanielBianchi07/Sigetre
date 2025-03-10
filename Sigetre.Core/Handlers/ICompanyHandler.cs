using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ICompanyHandler
{
    Task<Response<Company?>> CreateAsync(CreateCompanyRequest request);
    Task<Response<Company?>> DeleteAsync(DeleteCompanyRequest request);
    Task<Response<Company?>> UpdateAsync(UpdateCompanyRequest request);
    Task<Response<Company?>> GetByIdAsync(GetCompanyByIdRequest request);
    Task<PagedResponse<List<Company>>> GetAllAsync(GetAllCompanyRequest request);
}