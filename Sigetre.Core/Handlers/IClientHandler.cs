using Sigetre.Core.Models;
using Sigetre.Core.Requests.Client;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IClientHandler
{
    Task<Response<Client?>> CreateAsync(CreateClientRequest request);
    Task<Response<Client?>> DeleteAsync(DeleteClientRequest request);
    Task<Response<Client?>> UpdateAsync(UpdateClientRequest request);
    Task<Response<Client?>> GetByIdAsync(GetClientByIdRequest request);
    Task<PagedResponse<List<Client>>> GetAllAsync(GetAllClientRequest request);
}