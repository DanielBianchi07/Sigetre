using Sigetre.Core.Models;
using Sigetre.Core.Requests.Specialization;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ISpecializationHandler
{
    Task<Response<Specialization?>> CreateAsync(CreateSpecializationRequest request);
    Task<Response<Specialization?>> DeleteAsync(DeleteSpecializationRequest request);
    Task<Response<Specialization?>> UpdateAsync(UpdateSpecializationRequest request);
    Task<Response<Specialization?>> GetByIdAsync(GetSpecializationByIdRequest request);
    Task<PagedResponse<List<Specialization>>> GetAllAsync(GetAllSpecializationRequest request);
}