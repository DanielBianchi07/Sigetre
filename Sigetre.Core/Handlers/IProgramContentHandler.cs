using Sigetre.Core.Models;
using Sigetre.Core.Requests.ProgramContent;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IProgramContentHandler
{
    Task<Response<ProgramContent?>> CreateAsync(CreateProgramContentRequest request);
    Task<Response<ProgramContent?>> DeleteAsync(DeleteProgramContentRequest request);
    Task<Response<ProgramContent?>> UpdateAsync(UpdateProgramContentRequest request);
    Task<Response<ProgramContent?>> GetByIdAsync(GetProgramContentByIdRequest request);
    Task<PagedResponse<List<ProgramContent>>> GetByCourseAsync(GetProgramContentByCourseRequest request);
}