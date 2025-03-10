using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Enums;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Company;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class CompanyHandler(AppDbContext context) : ICompanyHandler
{
    public async Task<Response<Company?>> CreateAsync(CreateCompanyRequest request)
    {
        try
        {
                var company = new Company
                {
                    Name = request.Name,
                    Ein = request.Ein,
                    Email = request.Email,
                    User = request.User,
                    CreatedBy = request.User,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status
                };

                await context.Companies.AddAsync(company);
                await context.SaveChangesAsync();

                return new Response<Company?>(company, 201, "Empresa criada com sucesso");
        }
        catch
        {
            return new Response<Company?>(null, 500, "Não foi possível criar a empresa");
        }
    }

    public async Task<Response<Company?>> DeleteAsync(DeleteCompanyRequest request)
    {
        try
        {
                var company =
                    await context.Companies.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (company == null)
                    return new Response<Company?>(null, 404, "Empresa não encontrada");
                company.Status = EStatus.Inactive;
                context.Companies.Update(company);
                await context.SaveChangesAsync();

                return new Response<Company?>(company, message: "Empresa excluida com sucesso");
        }
        catch
        {
            return new Response<Company?>(null, 500, "Não foi possível excluir a empresa");
        }
    }

    public async Task<Response<Company?>> UpdateAsync(UpdateCompanyRequest request)
    {
        try
        {
                var company = await context.Companies.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

                if (company == null)
                    return new Response<Company?>(null, 404, "Empresa não encontrada");
                company.Name = request.Name;
                company.Ein = request.Ein;
                company.Email = request.Email;
                company.User = request.User;
                company.UpdatedBy = request.User;
                company.UpdatedAt = request.UpdatedAt;
                company.Status = request.Status;

                context.Companies.Update(company);
                await context.SaveChangesAsync();

                return new Response<Company?>(company);
        }
        catch
        {
            return new Response<Company?>(null, 500, "Não foi possível alterar a empresa");
        }
    }

    public async Task<Response<Company?>> GetByIdAsync(GetCompanyByIdRequest request)
    {
        try
        {
                var company = await context.Companies.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);
                return company is null
                    ? new Response<Company?>(null, 404, "Empresa não encontrada")
                    : new Response<Company?>(company);
        }
        catch
        {
            return new Response<Company?>(null, 500, "Não foi possível recuperar a empresa");
        }
    }

    public async Task<PagedResponse<List<Company>>> GetAllAsync(GetAllCompanyRequest request)
    {
        try
        {
                var query = context.Companies
                    .AsNoTracking()
                    .Where(x => x.User == request.User)
                    .OrderBy(x => x.Name);

                var companies = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Company>>(companies, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Company>>(null, 500, "Não foi possível consultar as empresas");
        }
    }
}