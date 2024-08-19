using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Alternative;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class AlternativeHandler(AppDbContext context) : IAlternativeHandler
{
    public async Task<Response<Alternative?>> CreateAsync(CreateAlternativeRequest request)
    {
        try
        {
            var alternative = new Alternative
            {
                Content = request.Content,
                Answer = request.Answer,
                QuestionId = request.QuestionId,
                User = request.User,
                CreatedBy = request.User,
                CreatedAt = request.CreatedAt,
                Status = request.Status
            };
            await context.Alternatives.AddAsync(alternative);
            await context.SaveChangesAsync();

            return new Response<Alternative?>(alternative, 201, "Alternativa cadastrada com sucesso");
        }
        catch
        {
            return new Response<Alternative?>(null, 500, "Não foi possível cadastrar a alternativa");
        }
    }

    public async Task<Response<Alternative?>> DeleteAsync(DeleteAlternativeRequest request)
    {
        try
        {
            var alternative =
                await context.Alternatives.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

            if (alternative == null)
                return new Response<Alternative?>(null, 404, "Alternativa não encontrada");
            context.Alternatives.Remove(alternative);
            await context.SaveChangesAsync();

            return new Response<Alternative?>(alternative, message: "Alternativa excluida com sucesso");
        }
        catch
        {
            return new Response<Alternative?>(null, 500, "Não foi possível excluir a alternativa");
        }
    }

    public async Task<Response<Alternative?>> UpdateAsync(UpdateAlternativeRequest request)
    {
        try
        {
            var alternative =
                await context.Alternatives.FirstOrDefaultAsync(x =>
                    x.Id == request.Id && x.User == request.User);

            if (alternative == null)
                return new Response<Alternative?>(null, 404, "Alternativa não encontrada");
            alternative.Content = request.Content;
            alternative.Answer = request.Answer;
            alternative.QuestionId = request.QuestionId;
            alternative.User = request.User;
            alternative.UpdatedBy = request.User;
            alternative.UpdatedAt = request.UpdatedAt;
            alternative.Status = request.Status;

            context.Alternatives.Update(alternative);
            await context.SaveChangesAsync();

            return new Response<Alternative?>(alternative);
        }
        catch
        {
            return new Response<Alternative?>(null, 500, "Não foi possível alterar a alternativa");
        }
    }

    public async Task<Response<Alternative?>> GetByIdAsync(GetAlternativeByIdRequest request)
    {
        try
        {
            var alternative = await context.Alternatives.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);
            return alternative is null
                ? new Response<Alternative?>(null, 404, "Alternativa não encontrada")
                : new Response<Alternative?>(alternative);
        }
        catch
        {
            return new Response<Alternative?>(null, 500, "Não foi possível recuperar a alternativa");
        }
    }

    public async Task<PagedResponse<List<Alternative>>> GetByQuestionAsync(GetAlternativeByQuestionRequest request)
    {
        try
        {
            var query = context.Alternatives
                .AsNoTracking()
                .Where(x => x.QuestionId == request.QuestionId && x.User == request.User)
                .OrderBy(x => x.Question.Content);

            var alternatives = await query
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Alternative>>(alternatives, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Alternative>>(null, 500, "Não foi possível consultar as alternativas");
        }
    }
}