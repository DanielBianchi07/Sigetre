using Sigetre.Core.Models;
using Sigetre.Core.Requests.Alternative;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IAlternativeHandler
{
    Task<Response<Alternative?>> CreateAsync(CreateAlternativeRequest request);
    Task<Response<Alternative?>> DeleteAsync(DeleteAlternativeRequest request);
    Task<Response<Alternative?>> UpdateAsync(UpdateAlternativeRequest request);
    Task<Response<Alternative?>> GetByIdAsync(GetAlternativeByIdRequest request);
    Task<PagedResponse<List<Alternative>>> GetByQuestionAsync(GetAlternativeByQuestionRequest request);
}
