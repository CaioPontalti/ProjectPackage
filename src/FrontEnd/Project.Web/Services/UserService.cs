using Newtonsoft.Json;
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

        var response = await _httpClient.GetAsync($"v1/user?page={page}&pageSize={pageSize}&search={search}");
        
        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException("Usuário sem autorização. Faça login novamente.");

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<GetAllUser>>(json);

        return result;
    }
}