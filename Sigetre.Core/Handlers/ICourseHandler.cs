using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ICourseHandler
{
    Task<Response<Course?>> CreateAsync(CreateCourseRequest request);
    Task<Response<Course?>> DeleteAsync(DeleteCourseRequest request);
    Task<Response<Course?>> UpdateAsync(UpdateCourseRequest request);
    Task<Response<Course?>> GetByIdAsync(GetCourseByIdRequest request);
    Task<PagedResponse<List<Course>>> GetAllCourseAsync(GetAllCourseRequest request);
}