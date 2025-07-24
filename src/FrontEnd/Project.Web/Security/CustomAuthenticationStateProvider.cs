using Microsoft.AspNetCore.Components.Authorization;
using Project.Web.Interfaces.Services.Security;
using System.Security.Claims;
using System.Text.Json;

namespace ProjectAuthentication.Web.Security;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAccessTokenService _accessTokenService;

    private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(IHttpContextAccessor accessor, IAccessTokenService accessTokenService)
    {
        _httpContextAccessor = accessor;
        _accessTokenService = accessTokenService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = _httpContextAccessor.HttpContext?.Request?.Cookies["access_token"];
        var tokenCookie = await _accessTokenService.GetTokenAsync();

        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrEmpty(tokenCookie))
        {
            MarkUserAsLoggedOut();
            return new AuthenticationState(_user);
        }

        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
        _user = new ClaimsPrincipal(identity);

        return new AuthenticationState(_user);
    }

    public void MarkUserAsAuthenticated(string token)
    {
        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
        _user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
    }

    public void MarkUserAsLoggedOut()
    {
        _user = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = Convert.FromBase64String(PadBase64(payload));
        var json = System.Text.Encoding.UTF8.GetString(jsonBytes);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value?.ToString() ?? ""));
    }

    private static string PadBase64(string base64)
    {
        return base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
    }
}