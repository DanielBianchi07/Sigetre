using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class CourseHandler(AppDbContext context) : ICourseHandler
{
    public Task<Response<Course?>> CreateAsync(CreateCourseRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Course?>> DeleteAsync(DeleteCourseRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Course?>> UpdateAsync(UpdateCourseRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Course?>> GetByIdAsync(GetCourseByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Course>>> GetByQuestionAsync(GetAllCourseRequest request)
    {
        throw new NotImplementedException();
    }
}