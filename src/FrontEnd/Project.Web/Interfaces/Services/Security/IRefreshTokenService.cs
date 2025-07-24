namespace Project.Web.Interfaces.Services.Security;

public interface IRefreshTokenService
{
    Task SetAsync(string valeu);
    Task<string> GetAsync();
    Task RemoveAsync();
}