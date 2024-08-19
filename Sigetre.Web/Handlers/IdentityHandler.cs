using System.Net.Http.Json;
using System.Text;
using Sigetre.Core.Handlers;
using Sigetre.Core.Requests.Identity;
using Sigetre.Core.Responses;

namespace Sigetre.Web.Handlers;

public class IdentityHandler(IHttpClientFactory _httpClientFactory) : IIdentityHandler
{
    private readonly HttpClient _client = _httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<Response<string>> LoginAsync(LoginRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
        return result.IsSuccessStatusCode
            ? new Response<string>("Login realizado com sucesso", 200, "Login realizado com sucesso")
            : new Response<string>(null, (int)result.StatusCode, "Não foi possível realizar o login");
    }

    public async Task<Response<string>> RegisterAsync(RegisterRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/identity/register", request);
        return result.IsSuccessStatusCode
            ? new Response<string>("Cadastro realizado com sucesso", 201, "Cadastro realizado com sucesso")
            : new Response<string>(null, (int)result.StatusCode, "Não foi possível realizar o cadastro");
    }

    public async Task LogoutAsync()
    {
        var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
        await _client.PostAsJsonAsync("v1/identity/logout", emptyContent);
    }
}