using Newtonsoft.Json;
using Project.Shared.Exceptions;
using Project.Web.DTOs;
using Project.Web.DTOs.Response.User.GetById;
using Project.Web.Interfaces.Services;
using Project.Web.Interfaces.Services.Security;
using System.Net;
using System.Net.Http;

namespace Project.Web.Services;

public class ProfileService : IProfileService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenService _accessTokenService;
    private readonly string _messageError = "Ocorreu um erro ao chamar a api. Entre em contato com o Suporte.";

    public ProfileService(IHttpClientFactory httpClientFactory, IAccessTokenService accessTokenService)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
        _accessTokenService = accessTokenService;
    }

    public async Task<ApiResponse<GetByIdProfile>> GetByIdAsync(string accountId)
    {
        var token = await _accessTokenService.GetTokenAsync();

        _httpClient.DefaultRequestHeaders.Remove("Authorization");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var response = await _httpClient.GetAsync($"v1/profile?accountId={accountId}");

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException("Usuário sem autorização. Faça login novamente.");

        if (response.StatusCode != HttpStatusCode.OK)
            throw new ApiResponseException(_messageError);

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<GetByIdProfile>>(json);

        return result;
    }
}
