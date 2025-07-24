namespace Project.Web.Interfaces.Services.Security;

public interface ICookieService
{
    Task<string> GetAsync(string key);
    Task RemoveAsync(string key);
    Task SetAsync(string key, string value, int days);
}
