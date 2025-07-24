using Newtonsoft.Json;
using Project.Web.DTOs;
using Project.Web.DTOs.Response.Auth;
using Project.Web.Interfaces.Services;

namespace Project.Web.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<ApiResponse<Login>> LoginAsync(string userName, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("v1/auth/login", new { email = userName, password });

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<Login>>(json);

        return result;
    }
}
