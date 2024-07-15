using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Course;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class CourseHandler(AppDbContext context) : ICourseHandler
{
    public async Task<Response<Course?>> CreateAsync(CreateCourseRequest request)
    {
        try
        {
            var course = new Course
            {
                Name = request.Name,
                InitialWorkload = request.InitialWorkload,
                PeriodicWorkload = request.PeriodicWorkload,
                Validity = request.Validity,
                Logo = request.Logo,
                SpecializationId = request.SpecializationId,
                CreatedAt = request.CreatedAt,
                Status = request.Status,
                ClientId = request.ClientId,
                CreatedBy = request.CreateBy,
            };

            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();

            return new Response<Course?>(course, 201, "Curso cadastrado com sucesso");
        }
        catch
        {
            return new Response<Course?>(null, 500, "Não foi possível cadastrar o curso");
        }
    }

    public async Task<Response<Course?>> DeleteAsync(DeleteCourseRequest request)
    {
        try
        {
            var course = await context.Courses.FirstOrDefaultAsync(x=>x.Id == request.Id && x.ClientId == request.ClientId);

            if (course == null)
                return new Response<Course?>(null, 404, "Curso não encontrado");

            context.Courses.Remove(course);
            await context.SaveChangesAsync();

            return new Response<Course?>(course, 200, "Curso removido com sucesso");
        }
        catch
        {
            return new Response<Course?>(null, 500, "Não foi possível cadastrar o curso");
        }
    }

    public async Task<Response<Course?>> UpdateAsync(UpdateCourseRequest request)
    {
        try
        {
            var course = await context.Courses.FirstOrDefaultAsync(x=>x.Id == request.Id && x.ClientId == request.ClientId);

            if (course == null)
                return new Response<Course?>(null, 404, "Curso não encontrado");
            
            course.Name = request.Name;
            course.InitialWorkload = request.InitialWorkload;
            course.PeriodicWorkload = request.PeriodicWorkload;
            course.Validity = request.Validity;
            course.Logo = request.Logo;
            course.SpecializationId = request.SpecializationId;
            course.UpdatedAt = request.UpdatedAt;
            course.Status = request.Status;
            course.ClientId = request.ClientId;
            course.UpdatedBy = request.UpdatedBy;

            context.Courses.Update(course);
            await context.SaveChangesAsync();

            return new Response<Course?>(course);
        }
        catch
        {
            return new Response<Course?>(null, 500, "Não foi possível alterar o curso");
        }
    }

    public async Task<Response<Course?>> GetByIdAsync(GetCourseByIdRequest request)
    {
        try
        {
            var course =
                await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);
            return course is null
                ? new Response<Course?>(null, 404, "Curso não encontrado")
                : new Response<Course?>(course);
        }
        catch
        {
            return new Response<Course?>(null, 500, "Não foi possível recuperar o curso");
        }
    }

    public async Task<PagedResponse<List<Course>>> GetAllCourseAsync(GetAllCourseRequest request)
    {
        try
        {
            var query = context.Courses.AsNoTracking().OrderBy(x => x.Name);

            var courses = await query
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ToListAsync();
            var count = await query.CountAsync();

            return new PagedResponse<List<Course>>(courses, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Course>>(null, 500, "Não foi possível consultar os cursos");
        }
    }
}