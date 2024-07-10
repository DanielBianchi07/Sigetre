using Sigetre.Core.Models;
using Sigetre.Core.Requests.Test;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface ITesteHandler
{
    Task<Response<Test?>> CreateAsync(CreateTestRequest request);
    Task<Response<Test?>> DeleteAsync(DeleteTestRequest request);
    Task<Response<Test?>> UpdateAsync(UpdateTestRequest request);
    Task<Response<Test?>> GetByIdAsync(GetTestByIdRequest request);
    Task<PagedResponse<List<Test>>> GetByQuestionAsync(GetTestByCourseRequest request);
}