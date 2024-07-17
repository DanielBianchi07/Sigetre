using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.AttendanceList;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class AttendanceListHandler(AppDbContext context) : IAttendanceListHandler
{
    public async Task<Response<AttendanceList?>> CreateAsync(CreateAttendanceListRequest request)
    {
        try
        {
            var attendanceList = new AttendanceList
            {
                Code = request.Code,
                TrainingStartedAt = request.TrainingStartedAt,
                Watermark = request.Watermark,
                Situation = request.Situation,
                ClientId = request.ClientId,
                CreatedBy = request.CreateBy,
                CreatedAt = request.CreatedAt,
                Status = request.Status
            };
            
            await context.AttendanceLists.AddAsync(attendanceList);
            await context.SaveChangesAsync();
            
            return new Response<AttendanceList?>(attendanceList, 201, "Lista de Presença cadastrada com sucesso");
        }
        catch
        {
            return new Response<AttendanceList?>(null, 500, "Não foi possível cadastrar a lista de presença");
        }
    }

    public Task<Response<AttendanceList?>> DeleteAsync(DeleteAttendanceListRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<AttendanceList?>> UpdateAsync(UpdateAttendanceListRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<AttendanceList?>> GetByIdAsync(GetAttendanceListByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<AttendanceList>>> GetByQuestionAsync(GetAllAttendanceListRequest request)
    {
        throw new NotImplementedException();
    }
}