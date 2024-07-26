using Sigetre.Core.Models;
using Sigetre.Core.Models.Birrelational;
using Sigetre.Core.Requests.Phones;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IPhoneHandler
{
    Task<Response<Phone?>> CreateAsync(CreatePhoneRequest request);
    Task<Response<Phone?>> DeleteAsync(DeletePhoneRequest request);
    Task<Response<Phone?>> UpdateAsync(UpdatePhoneRequest request);
    Task<PagedResponse<List<Phone>>> GetByCompanyAsync(GetPhoneByCompanyRequest request);
    Task<PagedResponse<List<Phone>>> GetByClientAsync(GetPhoneByClientRequest request);
}