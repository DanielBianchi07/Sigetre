using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Api.Models;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Test;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class TestHandler(AppDbContext context) : ITestHandler
{
    public async Task<Response<Test?>> CreateAsync(CreateTestRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName == request.User);
            if (user != null)
            {
                var test = new Test()
                {
                    Title = request.Title,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status,
                    CreatedBy = request.CreateBy,
                    ClientId = user.ClientId,
                };

                await context.Tests.AddAsync(test);
                await context.SaveChangesAsync();

                return new Response<Test?>(test, 201, "Prova cadastrada com sucesso");
            }
            else
                return new Response<Test?>(null, 404, "Nenhum usuário autenticado");
        }
        catch
        {
            return new Response<Test?>(null, 500, "Não foi possível cadastrar a prova");
        }
    }

    public async Task<Response<Test?>> DeleteAsync(DeleteTestRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName == request.User);
            if (user != null)
            {
                var test =
                    await context.Tests.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == user.ClientId);

                if (test == null)
                    return new Response<Test?>(null, 404, "Prova não encontrada");
                context.Tests.Remove(test);
                await context.SaveChangesAsync();

                return new Response<Test?>(test, message: "Prova excluída com sucesso");
            }
            else
                return new Response<Test?>(null, 404, "Nenhum usuário autenticado");
        }
        catch
        {
            return new Response<Test?>(null, 500, "Não foi possível excluir a prova");
        }
    }

    public async Task<Response<Test?>> UpdateAsync(UpdateTestRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName == request.User);
            if (user != null)
            {
                var test = await context.Tests.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == user.ClientId);

                if (test == null)
                    return new Response<Test?>(null, 404, "Prova não encontrada");

                test.Title = request.Title;
                test.UpdatedAt = request.UpdatedAt;
                test.Status = request.Status;
                test.UpdatedBy = request.UpdatedBy;
                test.ClientId = user.ClientId;

                context.Tests.Update(test);
                await context.SaveChangesAsync();

                return new Response<Test?>(test);
            }
            else
                return new Response<Test?>(null, 404, "Nenhum usuário autenticado");
        }
        catch
        {
            return new Response<Test?>(null, 500, "Não foi possível alterar a prova");
        }
    }

    public async Task<Response<Test?>> GetByIdAsync(GetTestByIdRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName == request.User);
            if (user != null)
            {
                var test = await context.Tests.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == user.ClientId);
                return test is null
                    ? new Response<Test?>(null, 404, "Prova não encontrada")
                    : new Response<Test?>(test);
            }
            else
                return new Response<Test?>(null, 404, "Nenhum usuário autenticado");
        }
        catch
        {
            return new Response<Test?>(null, 500, "Não foi possível recuperar a prova especificada");
        }
    }
}