using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Api.Models;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class PhoneHandler(AppDbContext context) : IPhoneHandler
{
    public async Task<Response<Phone?>> CreateAsync(CreatePhoneRequest request)
    {
        try
        {
                var phone = new Phone()
                {
                    Number = request.Number,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status,
                    CreatedBy = request.User,
                    CompanyId = request.CompanyId,
                    User = request.User,
                };

                await context.Phones.AddAsync(phone);
                await context.SaveChangesAsync();

                return new Response<Phone?>(phone, 201, "Telefone cadastrado com sucesso");
        }
        catch
        {
            return new Response<Phone?>(null, 500, "Não foi possível cadastrar o telefone");
        }
    }

    public async Task<Response<Phone?>> DeleteAsync(DeletePhoneRequest request)
    {
        try
        {
                var phone =
                    await context.Phones.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (phone == null)
                    return new Response<Phone?>(null, 404, "Telefone não encontrado");
                context.Phones.Remove(phone);
                await context.SaveChangesAsync();

                return new Response<Phone?>(phone, message: "Telefone excluído com sucesso");
        }
        catch
        {
            return new Response<Phone?>(null, 500, "Não foi possível excluir o telefone");
        }
    }

    public async Task<Response<Phone?>> UpdateAsync(UpdatePhoneRequest request)
    {
        try
        {
                var phone = await context.Phones.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (phone == null)
                    return new Response<Phone?>(null, 404, "Telefone não encontrado");

                phone.Number = request.Number;
                phone.User = request.User;
                phone.CompanyId = request.CompanyId;
                phone.UpdatedBy = request.User;
                phone.UpdatedAt = request.UpdatedAt;
                phone.Status = request.Status;

                context.Phones.Update(phone);
                await context.SaveChangesAsync();

                return new Response<Phone?>(phone);
        }
        catch
        {
            return new Response<Phone?>(null, 500, "Não foi possível alterar o telefone");
        }
    }

    public async Task<PagedResponse<List<Phone>>> GetByCompanyAsync(GetPhoneByCompanyRequest request)
    {
        try
        {
                var query = context.Phones
                    .AsNoTracking()
                    .Where(x => x.CompanyId == request.CompanyId && x.User == request.User)
                    .OrderBy(x => x.Company.Name);

                var phones = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Phone>>(phones, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Phone>>(null, 500, "Não foi possivel consultar os telefones");
        }
    }
}