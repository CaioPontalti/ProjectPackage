using Microsoft.JSInterop;
using Project.Web.Interfaces.Services.Security;

namespace Project.Web.Services.Security;

public class CookieService : ICookieService
{
    private readonly IJSRuntime _js;

    public CookieService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<string> GetAsync(string key)
    {
        return await _js.InvokeAsync<string>("getCookie", key);
    }

    public async Task RemoveAsync(string key)
    {
        await _js.InvokeVoidAsync("deleteCookie", key);
    }

    public async Task SetAsync(string key, string value, int days)
    {
        await _js.InvokeVoidAsync("setCookie", key, value, days);
    }
}