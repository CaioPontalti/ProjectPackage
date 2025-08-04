using Newtonsoft.Json;
using Project.Shared.Exceptions;
using Project.Web.DTOs;
using Project.Web.DTOs.Response.Account.Create;
using Project.Web.DTOs.Response.Account.GetAll;
using Project.Web.Interfaces.Services;
using Project.Web.Interfaces.Services.Security;
using System.Net;

namespace Project.Web.Services;

public class AccountService : IAccountService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenService _accessTokenService;
    private readonly string _messageError = "Ocorreu um erro ao chamar a api. Entre em contato com o Suporte.";

    public AccountService(IHttpClientFactory httpClientFactory, IAccessTokenService accessTokenService)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
        _accessTokenService = accessTokenService;
    }

    public async Task<ApiResponse<CreateAccount>> CreateAsync(string email, string password, string role, string accountType)
    {
        var response = await _httpClient.PostAsJsonAsync("v1/account", new { Email = email, Password = password, Role = role, AccountType = accountType});

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<CreateAccount>>(json);

        return result;
    }

    public async Task<ApiResponse<GetAllAccount>> GetAllAsync(int page, int pageSize, string search)
    {
        var token = await _accessTokenService.GetTokenAsync();

        _httpClient.DefaultRequestHeaders.Remove("Authorization");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var response = await _httpClient.GetAsync($"v1/account/accounts?page={page}&pageSize={pageSize}&search={search}");
        
        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException("Usuário sem autorização. Faça login novamente.");

        if (response.StatusCode != HttpStatusCode.OK)
            throw new ApiResponseException(_messageError);

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<GetAllAccount>>(json);

        return result;
    }
}