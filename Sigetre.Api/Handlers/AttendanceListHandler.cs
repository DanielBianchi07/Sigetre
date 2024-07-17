using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Enums;
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

    public async Task<Response<AttendanceList?>> DeleteAsync(DeleteAttendanceListRequest request)
    {
        try
        {
            var attendanceList =
                await context.AttendanceLists.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);

            if (attendanceList == null)
                return new Response<AttendanceList?>(null, 404, "Lista de presença não encontrada");
            attendanceList.Status = EStatus.Inactive;
            context.AttendanceLists.Update(attendanceList);
            await context.SaveChangesAsync();
            
            return new Response<AttendanceList?>(attendanceList, message:"Lista de presença excluida com sucesso");
        }
        catch
        {
            return new Response<AttendanceList?>(null, 500, "Não foi possível excluir a lista de presença");
        }
    }

    public async Task<Response<AttendanceList?>> UpdateAsync(UpdateAttendanceListRequest request)
    {
        try
        {
            var attendanceList =
                await context.AttendanceLists.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);

            if (attendanceList == null)
                return new Response<AttendanceList?>(null, 404, "Lista de presença não encontrada");
            attendanceList.Code = request.Code;
            attendanceList.TrainingStartedAt = request.TrainingStartedAt;
            attendanceList.Watermark = request.Watermark;
            attendanceList.Situation = request.Situation;
            attendanceList.ClientId = request.ClientId;
            attendanceList.UpdatedBy = request.UpdatedBy;
            attendanceList.UpdatedAt = request.UpdatedAt;
            attendanceList.Status = request.Status;

            context.AttendanceLists.Update(attendanceList);
            await context.SaveChangesAsync();

            return new Response<AttendanceList?>(attendanceList);
        }
        catch
        {
            return new Response<AttendanceList?>(null, 500, "Não foi possível alterar o cliente");
        }
    }

    public async Task<Response<AttendanceList?>> GetByIdAsync(GetAttendanceListByIdRequest request)
    {
        try
        {
            var attendanceList = await context.AttendanceLists.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);
            return attendanceList is null
                ? new Response<AttendanceList?>(null, 404, "Lista de presença não encontrada")
                : new Response<AttendanceList?>(attendanceList);
        }
        catch
        {
            return new Response<AttendanceList?>(null, 500, "Não foi possível recuperar a lista de presença");
        }
    }

    public async Task<PagedResponse<List<AttendanceList>>> GetAllAsync(GetAllAttendanceListRequest request)
    {
        try
        {
            var query = context.AttendanceLists
                .AsNoTracking()
                .Where(x => x.ClientId == request.ClientId)
                .OrderBy(x=>x.CreatedAt);

            var attendanceList = await query
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<AttendanceList>>(attendanceList, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<AttendanceList>>(null, 500, "Não foi possível consultar as listas de presença");
        }
    }
}