using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class AddressesHandler(AppDbContext context) : IAddressHandler
{
    public async Task<Response<Address?>> CreateAsync(CreateAddressRequest request)
    {
        try
        {
                var address = new Address
                {
                    ZipCode = request.ZipCode,
                    State = request.State,
                    City = request.City,
                    Neighborhood = request.Neighborhood,
                    StreetName = request.StreetName,
                    Number = request.Number,
                    Complement = request.Complement,
                    User = request.User,
                    CompanyId = request.CompanyId,
                    CreatedBy = request.User,
                    CreatedAt = request.CreatedAt,
                    Status = request.Status
                };

                await context.Addresses.AddAsync(address);
                await context.SaveChangesAsync();

                return new Response<Address?>(address, 201, "Endereço cadastrado com sucesso");
        }
        catch
        {
            return new Response<Address?>(null, 500, "Não foi possível cadastrar o endereço");
        }
    }

    public async Task<Response<Address?>> DeleteAsync(DeleteAddressRequest request)
    {
        try
        {
            var address =
                await context.Addresses.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

            if (address == null)
                return new Response<Address?>(null, 404, "Endereço não encontrado");
            context.Addresses.Remove(address);
            await context.SaveChangesAsync();

            return new Response<Address?>(address, message: "Endereço excluído com sucesso");
        }
        catch
        {
            return new Response<Address?>(null, 500, "Não foi possível excluir o endereço");
        }
    }

    public async Task<Response<Address?>> UpdateAsync(UpdateAddressRequest request)
    {
        try
        {
            var address = await context.Addresses.FirstOrDefaultAsync(x => x.Id == request.Id && x.User == request.User);

            if (address == null)
                return new Response<Address?>(null, 404, "Endereço não encontrado");

            address.ZipCode = request.ZipCode;
            address.State = request.State;
            address.City = request.City;
            address.Neighborhood = request.Neighborhood;
            address.StreetName = request.StreetName;
            address.Number = request.Number;
            address.Complement = request.Complement;
            address.User = request.User;
            address.CompanyId = request.CompanyId;
            address.UpdatedBy = request.User;
            address.UpdatedAt = request.UpdatedAt;
            address.Status = request.Status;

            context.Addresses.Update(address);
            await context.SaveChangesAsync();

            return new Response<Address?>(address);
        }
        catch
        {
            return new Response<Address?>(null, 500, "Não foi possível alterar o endereço");
        }
    }

    public async Task<Response<Address?>> GetByCompanyAsync(GetAddressByCompanyRequest request)
    {
        try
        {
            var address = await context.Addresses
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CompanyId == request.CompanyId && x.User == request.User);
            return address is null
                ? new Response<Address?>(null, 404, "Endereço não encontrado")
                : new Response<Address?>(address);
        }
        catch
        {
            return new Response<Address?>(null, 500, "Não foi possível recuperar o endereço");
        }
    }
}