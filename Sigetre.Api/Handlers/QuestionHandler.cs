using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Question;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class QuestionHandler(AppDbContext context) : IQuestionHandler
{
    public async Task<Response<Question?>> CreateAsync(CreateQuestionRequest request)
    {
        try
        {
            var question = new Question()
            {
                Content = request.Content,
                CorrectAnswer = request.CorrectAnswer,
                CourseId = request.CourseId,
                CreatedAt = request.CreatedAt,
                Status = request.Status,
                CreatedBy = request.CreateBy,
                ClientId = request.ClientId,
            };
            
            await context.Questions.AddAsync(question);
            await context.SaveChangesAsync();
            
            return new Response<Question?>(question, 201, "Questão cadastrada com sucesso");
        }
        catch
        {
            return new Response<Question?>(null, 500, "Não foi possível cadastrar a questão");
        }
    }

    public async Task<Response<Question?>> DeleteAsync(DeleteQuestionRequest request)
    {
        try
        {
            var question =
                await context.Questions.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);

            if (question == null)
                return new Response<Question?>(null, 404, "Questão não encontrada");
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
            
            return new Response<Question?>(question, message:"Questão excluída com sucesso");
        }
        catch
        {
            return new Response<Question?>(null, 500, "Não foi possível excluir a questão");
        }
    }

    public async Task<Response<Question?>> UpdateAsync(UpdateQuestionRequest request)
    {
        try
        {
            var question =
                await context.Questions.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (question == null)
                return new Response<Question?>(null, 404, "Questão não encontrada");
            
            question.Content = request.Content;
            question.CorrectAnswer = request.CorrectAnswer;
            question.CourseId = request.CourseId;
            question.UpdatedAt = request.UpdatedAt;
            question.Status = request.Status;
            question.UpdatedBy = request.UpdatedBy;
            question.ClientId = request.ClientId;

            context.Questions.Update(question);
            await context.SaveChangesAsync();

            return new Response<Question?>(question);
        }
        catch
        {
            return new Response<Question?>(null, 500, "Não foi possível alterar a questão");
        }
    }

    public async Task<Response<Question?>> GetByIdAsync(GetQuestionByIdRequest request)
    {
        try
        {
            var question = await context.Questions.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);
            return question is null
                ? new Response<Question?>(null, 404, "Questão não encontrada")
                : new Response<Question?>(question);
        }
        catch
        {
            return new Response<Question?>(null, 500, "Não foi possível recuperar a questão especificada");
        }
    }

    public async Task<PagedResponse<List<Question>>> GetByCourseAsync(GetQuestionByCourseRequest request)
    {
        try
        {
            var query = context.Questions
                .AsNoTracking()
                .Where(x => x.CourseId == request.CourseId && x.ClientId == request.ClientId)
                .OrderBy(x=>x.Course.Name);

            var questions = await query
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Question>>(questions, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Question>>(null, 500, "Não foi possível consultar questões do curso");
        }
    }
}