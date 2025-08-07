using Newtonsoft.Json;
using Project.Web.DTOs;
using Project.Web.DTOs.Response.Profile.GetByAccountId;
using Project.Web.Interfaces.Services;
using Project.Web.Interfaces.Services.Security;
using System.Net;

namespace Project.Web.Services;

public class ProfileService : IProfileService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenService _accessTokenService;

    public ProfileService(IHttpClientFactory httpClientFactory, IAccessTokenService accessTokenService)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
        _accessTokenService = accessTokenService;
    }

    public async Task<ApiResponse<GetByAccountId>> GetByIdAsync(string accountId)
    {
        var token = await _accessTokenService.GetTokenAsync();

        _httpClient.DefaultRequestHeaders.Remove("Authorization");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var response = await _httpClient.GetAsync($"v1/profile?accountId={accountId}");

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException("Usuário sem autorização. Faça login novamente.");

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<GetByAccountId>>(json);

        return result;
    }

    public async Task<ApiResponse> UpdateAsync(Profile profile)
    {
        var token = await _accessTokenService.GetTokenAsync();

        _httpClient.DefaultRequestHeaders.Remove("Authorization");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var response = await _httpClient.PutAsJsonAsync($"v1/profile", profile);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException("Usuário sem autorização. Faça login novamente.");

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse>(json);

        return result;
    }
}