using Project.Web.Interfaces.Services.Security;

namespace Project.Web.Services.Security;

public class AccessTokenService : IAccessTokenService
{
    private readonly ICookieService _cookieService;
    private readonly string tokenKey = "access_token";

    public AccessTokenService(ICookieService cookieService)
    {
        _cookieService = cookieService;
    }

    public async Task<string> GetTokenAsync()
    {
        return await _cookieService.GetAsync(tokenKey);
    }

    public async Task SetTokenAsync(string accessToken)
    {
        await _cookieService.SetAsync(tokenKey, accessToken, 1);
    }

    public async Task RemoveTokenAsync()
    {
        await _cookieService.RemoveAsync(tokenKey);
    }
}