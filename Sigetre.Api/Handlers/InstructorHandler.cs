using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class InstructorHandler : IInstructorHandler
{
    public Task<Response<Instructor?>> CreateAsync(CreateInstructorRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Instructor?>> DeleteAsync(DeleteInstructorRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Instructor?>> UpdateAsync(UpdateInstructorRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Instructor?>> GetByIdAsync(GetInstructorByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Instructor>>> GetByQuestionAsync(GetAllInstructorRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Instructor>>> GetByQuestionAsync(GetInstructorBySpecialityRequest request)
    {
        throw new NotImplementedException();
    }
}