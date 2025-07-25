using Newtonsoft.Json;
using Project.Web.DTOs;
using Project.Web.DTOs.Response.User;
using Project.Web.Interfaces.Services;

namespace Project.Web.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<ApiResponse<CreateUser>> CreateUser(string name, string email, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("v1/user", new { Name = name, Email = email, Password = password });

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResponse<CreateUser>>(json);

        return result;
    }
}
