using Sigetre.Core.Models;
using Sigetre.Core.Requests.AttendanceList;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IAttendanceListHandler
{
    Task<Response<AttendanceList?>> CreateAsync(CreateAttendanceListRequest request);
    Task<Response<AttendanceList?>> DeleteAsync(DeleteAttendanceListRequest request);
    Task<Response<AttendanceList?>> UpdateAsync(UpdateAttendanceListRequest request);
    Task<Response<AttendanceList?>> GetByIdAsync(GetAttendanceListByIdRequest request);
    Task<PagedResponse<List<AttendanceList>>> GetAllAsync(GetAllAttendanceListRequest request);
}