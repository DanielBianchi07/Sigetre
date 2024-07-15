using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Address;
using Sigetre.Core.Responses;

namespace Sigetre.Api.Handlers;

public class AddressesHandler(AppDbContext context) : IAddressHandler
{
    public async Task<Response<Addresses?>> CreateAsync(CreateAddressRequest request)
    {
        try
        {
            var address = new Addresses
            {
                ZipCode = request.ZipCode,
                State = request.State,
                City = request.City,
                District = request.District,
                StreetName = request.StreetName,
                Number = request.Number,
                Complement = request.Complement,
                ClientId = request.ClientId,
                CreatedBy = request.CreateBy,
                CreatedAt = request.CreatedAt,
                Status = request.Status
            };
            
            await context.Addresses.AddAsync(address);
            await context.SaveChangesAsync();
            
            return new Response<Addresses?>(address, 201, "Endereço cadastrado com sucesso");
        }
        catch
        {
            return new Response<Addresses?>(null, 500, "Não foi possível cadastrar o endereço");
        }
    }

    public async Task<Response<Addresses?>> DeleteAsync(DeleteAddressRequest request)
    {
        try
        {
            var address =
                await context.Addresses.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);

            if (address == null)
                return new Response<Addresses?>(null, 404, "Endereço não encontrado");
            context.Addresses.Remove(address);
            await context.SaveChangesAsync();
            
            return new Response<Addresses?>(address, message:"Endereço excluído com sucesso");
        }
        catch
        {
            return new Response<Addresses?>(null, 500, "Não foi possível excluir o endereço");
        }
    }

    public async Task<Response<Addresses?>> UpdateAsync(UpdateAddressRequest request)
    {
        try
        {
            var address =
                await context.Addresses.FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);

            if (address == null)
                return new Response<Addresses?>(null, 404, "Endereço não encontrado");

            address.ZipCode = request.ZipCode;
            address.State = request.State;
            address.City = request.City;
            address.District = request.District;
            address.StreetName = request.StreetName;
            address.Number = request.Number;
            address.Complement = request.Complement;
            address.ClientId = request.ClientId;
            address.UpdatedBy = request.UpdatedBy;
            address.UpdatedAt = request.UpdatedAt;
            address.Status = request.Status;

            context.Addresses.Update(address);
            await context.SaveChangesAsync();

            return new Response<Addresses?>(address);
        }
        catch
        {
            return new Response<Addresses?>(null, 500, "Não foi possível alterar o endereço");
        }
    }

    public async Task<Response<Addresses?>> GetByIdAsync(GetAddressByIdRequest request)
    {
        try
        {
            var address = await context.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.ClientId == request.ClientId);
            return address is null
                ? new Response<Addresses?>(null, 404, "Endereço não encontrado")
                : new Response<Addresses?>(address);
        }
        catch
        {
            return new Response<Addresses?>(null, 500, "Não foi possível recuperar o endereço");
        }
    }

    public Task<PagedResponse<List<Addresses>>> GetByCompanyOrClientIdAsync(GetAddressByCompanyOrClientRequest request)
    {
        throw new NotImplementedException();
    }
}