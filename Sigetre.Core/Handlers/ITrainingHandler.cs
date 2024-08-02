using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ITrainingHandler
{
    Task<Response<Training?>> CreateAsync(CreateTrainingRequest request);
    Task<Response<Training?>> DeleteAsync(DeleteTrainingRequest request);
    Task<Response<Training?>> UpdateAsync(UpdateTrainingRequest request);
    Task<Response<Training?>> GetByIdAsync(GetTrainingByIdRequest request);
    Task<PagedResponse<List<Training>>> GetAllAsync(GetAllTrainingRequest request);
    Task<PagedResponse<List<Training>>> GetByCourseAsync(GetTrainingByCourseRequest request);
    Task<PagedResponse<List<Training>>> GetByInstructorAsync(GetTrainingByInstructorRequest request);
    Task<PagedResponse<List<Training>>> GetByStudentAsync(GetTrainingByStudentRequest request);
    Task<PagedResponse<List<Training>>> GetByDateAsync(GetTrainingByDateRequest request);
}