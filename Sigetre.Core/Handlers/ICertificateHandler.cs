using Sigetre.Core.Models;
using Sigetre.Core.Requests.Certificate;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ICertificateHandler
{
    Task<Response<Certificate?>> CreateAsync(CreateCertificateRequest request);
    Task<Response<Certificate?>> DeleteAsync(DeleteCertificateRequest request);
    Task<Response<Certificate?>> UpdateAsync(UpdateCertificateRequest request);
    Task<Response<Certificate?>> GetByIdAsync(GetCertificateByIdRequest request);
    Task<PagedResponse<List<Certificate>>> GetByQuestionAsync(GetAllCertificateRequest request);
}