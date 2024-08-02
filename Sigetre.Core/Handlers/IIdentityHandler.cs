using Sigetre.Core.Requests.Identity;
using Sigetre.Core.Responses;

namespace Sigetre.Core.Handlers;

public interface IIdentityHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}