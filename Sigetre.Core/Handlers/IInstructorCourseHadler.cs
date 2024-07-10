using Sigetre.Core.Models;
using Sigetre.Core.Requests.InstructorCourse;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IInstructorCourseHadler
{
    Task<Response<InstructorCourse?>> CreateAsync(CreateInstructorCourseRequest request);
    Task<Response<InstructorCourse?>> DeleteAsync(DeleteInstructorCourseRequest request);
    Task<Response<InstructorCourse?>> UpdateAsync(UpdateInstructorCourseRequest request);
    Task<Response<InstructorCourse?>> GetByIdAsync(GetInstructorCourseByIdRequest request);
}