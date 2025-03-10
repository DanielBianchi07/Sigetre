using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.ProgramContent;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class ProgramContentHandler(AppDbContext context) : IProgramContentHandler
{
    public async Task<Response<ProgramContent?>> CreateAsync(CreateProgramContentRequest request)
    {
        try
        {
                var programContent = new ProgramContent()
                {
                    Subject = request.Subject,
                    Workload = request.Workload,
                    CourseId = request.CourseId,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status,
                    CreatedBy = request.User,
                    User = request.User,
                };

                await context.ProgramContents.AddAsync(programContent);
                await context.SaveChangesAsync();

                return new Response<ProgramContent?>(programContent, 201,
                    "Conteúdo programático cadastrado com sucesso");
        }
        catch
        {
            return new Response<ProgramContent?>(null, 500, "Não foi possível cadastrar o conteúdo programático");
        }
    }

    public async Task<Response<ProgramContent?>> DeleteAsync(DeleteProgramContentRequest request)
    {
        try
        {
                var programContent =
                    await context.ProgramContents.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (programContent == null)
                    return new Response<ProgramContent?>(null, 404, "Conteúdo programático não encontrado");
                context.ProgramContents.Remove(programContent);
                await context.SaveChangesAsync();

                return new Response<ProgramContent?>(programContent,
                    message: "Conteúdo programático excluído com sucesso");
        }
        catch
        {
            return new Response<ProgramContent?>(null, 500, "Não foi possível excluir o conteúdo programático");
        }
    }
    public async Task<Response<ProgramContent?>> UpdateAsync(UpdateProgramContentRequest request)

    {
        try
        {
                var programContent = await context.ProgramContents.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (programContent == null)
                    return new Response<ProgramContent?>(null, 404, "Conteúdo programático não encontrado");

                programContent.Subject = request.Subject;
                programContent.Workload = request.Workload;
                programContent.CourseId = request.CourseId;
                programContent.UpdatedAt = request.UpdatedAt;
                programContent.Status = request.Status;
                programContent.UpdatedBy = request.User;
                programContent.User = request.User;

                context.ProgramContents.Update(programContent);
                await context.SaveChangesAsync();

                return new Response<ProgramContent?>(programContent);
        }
        catch
        {
            return new Response<ProgramContent?>(null, 500, "Não foi possível alterar o conteúdo programático");
        }
    }

    public async Task<Response<ProgramContent?>> GetByIdAsync(GetProgramContentByIdRequest request)
    {
        try
        {
                var programContent = await context.ProgramContents.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);
                return programContent is null
                    ? new Response<ProgramContent?>(null, 404, "Conteúdo programático não encontrado")
                    : new Response<ProgramContent?>(programContent);
        }
        catch
        {
            return new Response<ProgramContent?>(null, 500, "Não foi possível recuperar o conteúdo programático especificado");
        }
    }

    public async Task<PagedResponse<List<ProgramContent>>> GetByCourseAsync(GetProgramContentByCourseRequest request)
    {
        try
        {
                var query = context.ProgramContents
                    .AsNoTracking()
                    .Where(x => x.CourseId == request.CourseId && x.User == request.User)
                    .OrderBy(x => x.Course.Name);

                var programContents = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<ProgramContent>>(programContents, count, request.PageNumber,
                    request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<ProgramContent>>(null, 500, "Não foi possível consultar os conteúdos programáticos do curso");
        }
    }
}