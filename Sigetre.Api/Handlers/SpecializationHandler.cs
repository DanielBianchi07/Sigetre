using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Specialization;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class SpecializationHandler(AppDbContext context) : ISpecializationHandler
{
    public async Task<Response<Specialization?>> CreateAsync(CreateSpecializationRequest request)
    {
        try
        {
                var specialization = new Specialization
                {
                    Name = request.Name,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status,
                    User = request.User,
                    CreatedBy = request.User,
                };

                await context.Specializations.AddAsync(specialization);
                await context.SaveChangesAsync();

                return new Response<Specialization?>(specialization, 201, "Especialização cadastrada com sucesso");
        }
        catch
        {
            return new Response<Specialization?>(null, 500, "Não foi possível cadastrar a especialização");
        }
    }

    public async Task<Response<Specialization?>> DeleteAsync(DeleteSpecializationRequest request)
    {
        try
        {
                var specialization =
                    await context.Specializations.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (specialization == null)
                    return new Response<Specialization?>(null, 404, "Especialização não encontrada");
                context.Specializations.Remove(specialization);
                await context.SaveChangesAsync();

                return new Response<Specialization?>(specialization, message: "Especialização excluída com sucesso");
        }
        catch
        {
            return new Response<Specialization?>(null, 500, "Não foi possível excluir a especialização");
        }    
    }

    public async Task<Response<Specialization?>> UpdateAsync(UpdateSpecializationRequest request)
    {
        try
        {
                var specialization = await context.Specializations.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (specialization == null)
                    return new Response<Specialization?>(null, 404, "Especialização não encontrada");

                specialization.Name = request.Name;
                specialization.UpdatedAt = request.UpdatedAt;
                specialization.Status = request.Status;
                specialization.User = request.User;
                specialization.UpdatedBy = request.User;

                context.Specializations.Update(specialization);
                await context.SaveChangesAsync();

                return new Response<Specialization?>(specialization);
        }
        catch
        {
            return new Response<Specialization?>(null, 500, "Não foi possível alterar a especialização");
        }
    }

    public async Task<Response<Specialization?>> GetByIdAsync(GetSpecializationByIdRequest request)
    {
        try
        {
                var specialization = await context.Specializations.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);
                return specialization is null
                    ? new Response<Specialization?>(null, 404, "Especialização não encontrada")
                    : new Response<Specialization?>(specialization);
        }
        catch
        {
            return new Response<Specialization?>(null, 500, "Não foi possível recuperar a especialização especificada");
        }
    }

    public async Task<PagedResponse<List<Specialization>>> GetAllAsync(GetAllSpecializationRequest request)
    {
        try
        {
                var query = context.Specializations
                    .AsNoTracking()
                    .Where(x => x.User == request.User)
                    .OrderBy(x => x.Name);

                var specializations = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Specialization>>(specializations, count, request.PageNumber,
                    request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Specialization>>(null, 500, "Não foi possível consultar as especializações existentes");
        }
    }
}