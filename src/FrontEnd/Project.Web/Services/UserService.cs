using Newtonsoft.Json;
using Project.Shared.Exceptions;
using Project.Web.DTOs;
using Project.Web.DTOs.Response.User.Create;
using Project.Web.DTOs.Response.User.GetAll;
using Project.Web.Interfaces.Services;
using Project.Web.Interfaces.Services.Security;
using System.Net;

namespace Project.Web.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenService _accessTokenService;
    private readonly string _messageError = "Ocorreu um erro ao chamar a api. Entre em contato com o Suporte.";

    public UserService(IHttpClientFactory httpClientFactory, IAccessTokenService accessTokenService)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
        _accessTokenService = accessTokenService;
    }

    public async Task<ApiResponse<CreateUser>> CreateUserAsync(string name, string email, string password, string role)
    {
        var response = await _httpClient.PostAsJsonAsync("v1/user", new { Name = name, Email = email, Password = password, Role = role });

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<CreateUser>>(json);

        return result;
    }

    public async Task<ApiResponse<GetAllUser>> GetAllAsync(int page, int pageSize, string search)
    {
        var token = await _accessTokenService.GetTokenAsync();

        _httpClient.DefaultRequestHeaders.Remove("Authorization");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var response = await _httpClient.GetAsync($"v1/user/users?page={page}&pageSize={pageSize}&search={search}");
        
        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException("Usuário sem autorização. Faça login novamente.");

        if (response.StatusCode != HttpStatusCode.OK)
            throw new ApiResponseException(_messageError);

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<GetAllUser>>(json);

        return result;
    }
}