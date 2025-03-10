using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Api.Models;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Student;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class StudentHandler(AppDbContext context) : IStudentHandler
{
    public async Task<Response<Student?>> CreateAsync(CreateStudentRequest request)
    {
        try
        {
                var company = await context.Companies.FirstOrDefaultAsync(x => x.Id == request.CompanyId);
                if(company == null)
                    return new Response<Student?>(null, 404, "Não foi possível localizar a empresa");
                var student = new Student()
                {
                    Name = request.Name,
                    Ssn = request.Ssn,
                    Ic = request.Ic,
                    Email = request.Email,
                    Telephone = request.Telephone,
                    Signature = request.Signature,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status,
                    User = request.User,
                    CreatedBy = request.User,
                };
                
                student.Companies.Add(company);
                
                await context.Students.AddAsync(student);
                await context.SaveChangesAsync();

                return new Response<Student?>(student, 201, "Aluno cadastrado com sucesso");
        }
        catch
        {
            return new Response<Student?>(null, 500, "Não foi possível cadastrar o aluno");
        }
    }

    public async Task<Response<Student?>> DeleteAsync(DeleteStudentRequest request)
    {
        try
        {
                var student =
                    await context.Students.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (student == null)
                    return new Response<Student?>(null, 404, "Aluno não encontrado");

                context.Students.Remove(student);
                await context.SaveChangesAsync();

                return new Response<Student?>(student, 200, "Aluno removido com sucesso");
        }
        catch
        {
            return new Response<Student?>(null, 500, "Não foi possível cadastrar o aluno");
        }
    }

    public async Task<Response<Student?>> UpdateAsync(UpdateStudentRequest request)
    {
        try
        {
                var company = await context.Companies.FirstOrDefaultAsync(x => x.Id == request.CompanyId);
                if(company == null)
                    return new Response<Student?>(null, 404, "Não foi possível localizar a empresa");
                
                var student = await context.Students.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);
                if (student == null)
                    return new Response<Student?>(null, 404, "Aluno não encontrado");

                student.Name = request.Name;
                student.Ssn = request.Ssn;
                student.Ic = request.Ic;
                student.Email = request.Email;
                student.Telephone = request.Telephone;
                student.Signature = request.Signature;
                student.UpdatedAt = request.UpdatedAt;
                student.Status = request.Status;
                student.User = request.User;
                student.UpdatedBy = request.User;

                student.Companies.Add(company);
                
                context.Students.Update(student);
                await context.SaveChangesAsync();

                return new Response<Student?>(student);
        }
        catch
        {
            return new Response<Student?>(null, 500, "Não foi possível alterar o aluno");
        }
    }

    public async Task<Response<Student?>> GetByIdAsync(GetStudentByIdRequest request)
    {
        try
        {
                var student =
                    await context.Students.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);
                return student is null
                    ? new Response<Student?>(null, 404, "Aluno não encontrado")
                    : new Response<Student?>(student);
        }
        catch
        {
            return new Response<Student?>(null, 500, "Não foi possível recuperar o aluno");
        }
    }

    public async Task<PagedResponse<List<Student>>> GetAllAsync(GetAllStudentRequest request)
    {
        try
        {
                var query = context.Students
                    .AsNoTracking()
                    .Where(x => x.User == request.User)
                    .OrderBy(x => x.Name);

                var students = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Student>>(students, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Student>>(null, 500, "Não foi possível consultar os alunos");
        }
    }
}