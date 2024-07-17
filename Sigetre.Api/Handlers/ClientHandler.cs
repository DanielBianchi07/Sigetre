using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Enums;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Client;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class ClientHandler(AppDbContext context) : IClientHandler
{
    public async Task<Response<Client?>> CreateAsync(CreateClientRequest request)
    {
        try
        {
            var client = new Client
            {
                Name = request.Name,
                Ein = request.Ein,
                Email = request.Email,
                CreatedBy = request.CreateBy,
                CreatedAt = request.CreatedAt,
                Status = request.Status
            };

            await context.Clients.AddAsync(client);
            await context.SaveChangesAsync();

            return new Response<Client?>(client, 201, "Cliente criado com sucesso");
        }
        catch
        {
            return new Response<Client?>(null, 500, "Não foi possível criar o cliente");
        }
    }

    public async Task<Response<Client?>> DeleteAsync(DeleteClientRequest request)
    {
        try
        {
            var client =
                await context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (client == null)
                return new Response<Client?>(null, 404, "Cliente não encontrado");
            client.Status = EStatus.Inactive;
            context.Clients.Update(client);
            await context.SaveChangesAsync();
            
            return new Response<Client?>(client, message:"Cliente excluido com sucesso");
        }
        catch
        {
            return new Response<Client?>(null, 500, "Não foi possível excluir o cliente");
        }
    }

    public async Task<Response<Client?>> UpdateAsync(UpdateClientRequest request)
    {
        try
        {
            var client =
                await context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (client == null)
                return new Response<Client?>(null, 404, "Cliente não encontrado");
            client.Name = request.Name;
            client.Ein = request.Ein;
            client.Email = request.Email;
            client.UpdatedBy = request.UpdatedBy;
            client.UpdatedAt = request.UpdatedAt;
            client.Status = request.Status;

            context.Clients.Update(client);
            await context.SaveChangesAsync();

            return new Response<Client?>(client);
        }
        catch
        {
            return new Response<Client?>(null, 500, "Não foi possível alterar o cliente");
        }
    }

    public async Task<Response<Client?>> GetByIdAsync(GetClientByIdRequest request)
    {
        try
        {
            var client = await context.Clients.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            return client is null
                ? new Response<Client?>(null, 404, "Cliente não encontrado")
                : new Response<Client?>(client);
        }
        catch
        {
            return new Response<Client?>(null, 500, "Não foi possível recuperar o cliente");
        }
    }

    public async Task<PagedResponse<List<Client>>> GetAllAsync(GetAllClientRequest request)
    {
        try
        {
            var query = context.Clients
                .AsNoTracking()
                .OrderBy(x=>x.Name);

            var clients = await query
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Client>>(clients, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Client>>(null, 500, "Não foi possível consultar os clientes");
        }
    }
}