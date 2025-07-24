using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.Tokens;
using Project.Web.Interfaces.Services.Security;

namespace Project.Web.Services.Security;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ICookieService _cookieService;
    private readonly string _key = "refresh_token";

    public RefreshTokenService(ICookieService cookieService)
    {
        _cookieService = cookieService;
    }

    public async Task SetAsync(string valeu)
    {
        await _cookieService.SetAsync(_key, valeu, 1);
    }

    public async Task<string> GetAsync()
    {
        var result = await _cookieService.GetAsync(_key);
        if (!string.IsNullOrEmpty(result))
            return result;

        return string.Empty;
    }

    public async Task RemoveAsync()
    {
        await _cookieService.RemoveAsync(_key);
    }
}