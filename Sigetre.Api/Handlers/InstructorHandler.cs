using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Instructor;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class InstructorHandler(AppDbContext context) : IInstructorHandler
{
    public async Task<Response<Instructor?>> CreateAsync(CreateInstructorRequest request)
    {
        try
        {
                var instructor = new Instructor
                {
                    Name = request.Name,
                    Ssn = request.Ssn,
                    Email = request.Email,
                    Registry = request.Registry,
                    Telephone = request.Telephone,
                    Signature = request.Signature,
                    SpecializationId = request.SpecializationId,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status,
                    User = request.User,
                    CreatedBy = request.User,
                };

                await context.Instructors.AddAsync(instructor);
                await context.SaveChangesAsync();

                return new Response<Instructor?>(instructor, 201, "Instrutor cadastrado com sucesso");
        }
        catch
        {
            return new Response<Instructor?>(null, 500, "Não foi possível cadastrar o instrutor");
        }
    }

    public async Task<Response<Instructor?>> DeleteAsync(DeleteInstructorRequest request)
    {
        try
        {
                var instructor = await context.Instructors.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (instructor == null)
                    return new Response<Instructor?>(null, 404, "Instrutor não encontrado");

                context.Instructors.Remove(instructor);
                await context.SaveChangesAsync();

                return new Response<Instructor?>(instructor, 200, "Instrutor removido com sucesso");
        }
        catch
        {
            return new Response<Instructor?>(null, 500, "Não foi possível cadastrar o instrutor");
        }
    }

    public async Task<Response<Instructor?>> UpdateAsync(UpdateInstructorRequest request)
    {
        try
        {
                var instructor = await context.Instructors.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (instructor == null)
                    return new Response<Instructor?>(null, 404, "Instrutor não encontrado");

                instructor.Name = request.Name;
                instructor.Ssn = request.Ssn;
                instructor.Email = request.Email;
                instructor.Registry = request.Registry;
                instructor.Telephone = request.Telephone;
                instructor.Signature = request.Signature;
                instructor.SpecializationId = request.SpecializationId;
                instructor.UpdatedAt = request.UpdatedAt;
                instructor.Status = request.Status;
                instructor.User = request.User;
                instructor.UpdatedBy = request.User;

                context.Instructors.Update(instructor);
                await context.SaveChangesAsync();

                return new Response<Instructor?>(instructor);
        }
        catch
        {
            return new Response<Instructor?>(null, 500, "Não foi possível alterar o instrutor");
        }
    }

    public async Task<Response<Instructor?>> GetByIdAsync(GetInstructorByIdRequest request)
    {
        try
        {
                var instructor =
                    await context.Instructors.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);
                return instructor is null
                    ? new Response<Instructor?>(null, 404, "Instrutor não encontrado")
                    : new Response<Instructor?>(instructor);
        }
        catch
        {
            return new Response<Instructor?>(null, 500, "Não foi possível recuperar o instrutor");
        }
    }

    public async Task<PagedResponse<List<Instructor>>> GetAllAsync(GetAllInstructorRequest request)
    {
        try
        {
                var query = context.Instructors
                    .AsNoTracking()
                    .Where(x => x.User == request.User)
                    .OrderBy(x => x.Name);

                var instructors = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Instructor>>(instructors, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Instructor>>(null, 500, "Não foi possível consultar os instrutores");
        }
    }

    public async Task<PagedResponse<List<Instructor>>> GetBySpecializationAsync(GetInstructorBySpecialityRequest request)
    {
        try
        {
                var query = context.Instructors
                    .AsNoTracking()
                    .Where(x => x.SpecializationId == request.SpecialityId && x.User == request.User)
                    .OrderBy(x => x.Name);

                var instructors = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Instructor>>(instructors, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Instructor>>(null, 500, "Não foi possível consultar os instrutores");
        }
    }
}