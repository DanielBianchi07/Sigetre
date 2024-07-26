using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Enums;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Training;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class TrainingHandler(AppDbContext context) : ITrainingHandler
{
    public async Task<Response<Training?>> CreateAsync(CreateTrainingRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName == request.User);
            if (user != null)
            {
                var student = await context.Students.FirstOrDefaultAsync(x => x.Id == request.StudentId);
                if (student == null)
                    return new Response<Training?>(null, 404, "Não foi possível localizar o aluno");
            
                var instructor = await context.Instructors.FirstOrDefaultAsync(x => x.Id == request.InstructorId);
                if (instructor == null)
                    return new Response<Training?>(null, 404, "Não foi possível localizar o instrutor");

                var training = new Training()
                {
                    Type = request.Type,
                    Situation = request.Situation,
                    CourseId = request.CourseId,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status,
                    CreatedBy = request.CreateBy,
                    ClientId = user.ClientId
                };
                
                training.Students.Add(student);
                training.Instructors.Add(instructor);

                await context.Trainings.AddAsync(training);
                await context.SaveChangesAsync();

                return new Response<Training?>(training, 201, "Treinamento cadastrado com sucesso");
            }
            else
                return new Response<Training?>(null, 404, "Nenhum usuário autenticado");
        }
        catch
        {
            return new Response<Training?>(null, 500, "Não foi possível cadastrar o treinamento");
        }
    }

    public async Task<Response<Training?>> DeleteAsync(DeleteTrainingRequest request)
    {
        try
        {
            var training = await context.Trainings.FirstOrDefaultAsync(x=>x.Id == request.Id && x.ClientId == request.ClientId);

            if (training == null)
                return new Response<Training?>(null, 404, "Treinamento não encontrado");

            training.Situation = ETrainingSituation.Canceled;
            training.Status = EStatus.Inactive;
            
            context.Trainings.Update(training);
            await context.SaveChangesAsync();

            return new Response<Training?>(training, 200, "Treinamento inativado com sucesso");
        }
        catch
        {
            return new Response<Training?>(null, 500, "Não foi possível cadastrar o treinamento");
        }
    }

    public async Task<Response<Training?>> UpdateAsync(UpdateTrainingRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName == request.User);
            if (user != null)
            {
                var student = await context.Students.FirstOrDefaultAsync(x => x.Id == request.StudentId);
                if (student == null)
                    return new Response<Training?>(null, 404, "Não foi possível localizar o aluno");

                var instructor = await context.Instructors.FirstOrDefaultAsync(x => x.Id == request.InstructorId);
                if (instructor == null)
                    return new Response<Training?>(null, 404, "Não foi possível localizar o instrutor");

                var training = await context.Trainings.FirstOrDefaultAsync(x =>
                        x.Id == request.Id && x.ClientId == request.ClientId);

                if (training == null)
                    return new Response<Training?>(null, 404, "Treinamento não encontrado");

                training.Type = request.Type;
                training.Situation = request.Situation;
                training.CourseId = request.CourseId;
                training.CreatedAt = request.CreatedAt;
                training.Status = request.Status;
                training.CreatedBy = request.CreateBy;
                training.ClientId = user.ClientId;

                training.Students.Add(student);
                training.Instructors.Add(instructor);

                context.Trainings.Update(training);
                await context.SaveChangesAsync();

                return new Response<Training?>(training);
            }
            else
                return new Response<Training?>(null, 404, "Nenhum usuário autenticado");
        }
        catch
        {
            return new Response<Training?>(null, 500, "Não foi possível alterar o treinamento");
        }
    }

    public async Task<Response<Training?>> GetByIdAsync(GetTrainingByIdRequest request)
    {
        try
        {
            var training =
                await context.Trainings
                    .Include(x=>x.Course)
                    .Include(x=>x.Instructors)
                    .Include(x=>x.Students)
                    .ThenInclude(x=>x.Companies)
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);
            return training is null
                ? new Response<Training?>(null, 404, "Treinamento não encontrado")
                : new Response<Training?>(training);
        }
        catch
        {
            return new Response<Training?>(null, 500, "Não foi possível recuperar o treinamento");
        }
    }

    public async Task<PagedResponse<List<Training>>> GetAllAsync(GetAllTrainingRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName == request.User);
            if (user != null)
            {
                var query = context.Trainings
                    .AsNoTracking()
                    .Include(x=>x.Course)
                    .Include(x=>x.Instructors)
                    .Include(x=>x.Students)
                    .ThenInclude(x=>x.Companies)
                    .Where(x => x.ClientId == user.ClientId)
                    .OrderByDescending(x => x.CreatedAt);

                var trainings = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Training>>(trainings, count, request.PageNumber, request.PageSize);
            }
            else
                return new PagedResponse<List<Training>>(null, 404, "Nenhum usuário autenticado");
        }
        catch
        {
            return new PagedResponse<List<Training>>(null, 500, "Não foi possível consultar os treinamentos");
        }
    }
}