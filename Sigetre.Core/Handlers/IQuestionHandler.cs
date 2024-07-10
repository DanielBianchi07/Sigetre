using Sigetre.Core.Models;
using Sigetre.Core.Requests.Question;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IQuestionHandler
{
    Task<Response<Question?>> CreateAsync(CreateQuestionRequest request);
    Task<Response<Question?>> DeleteAsync(DeleteQuestionRequest request);
    Task<Response<Question?>> UpdateAsync(UpdateQuestionRequest request);
    Task<Response<Question?>> GetByIdAsync(GetQuestionByIdRequest request);
    Task<PagedResponse<List<Question>>> GetByQuestionAsync(GetQuestionByCourseRequest request);
}