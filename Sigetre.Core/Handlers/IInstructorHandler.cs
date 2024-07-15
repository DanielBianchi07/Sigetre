using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IInstructorHandler
{
    Task<Response<Instructor?>> CreateAsync(CreateInstructorRequest request);
    Task<Response<Instructor?>> DeleteAsync(DeleteInstructorRequest request);
    Task<Response<Instructor?>> UpdateAsync(UpdateInstructorRequest request);
    Task<Response<Instructor?>> GetByIdAsync(GetInstructorByIdRequest request);
    Task<PagedResponse<List<Instructor>>> GetAllAsync(GetAllInstructorRequest request);
    Task<PagedResponse<List<Instructor>>> GetBySpecializationAsync(GetInstructorBySpecialityRequest request);
}