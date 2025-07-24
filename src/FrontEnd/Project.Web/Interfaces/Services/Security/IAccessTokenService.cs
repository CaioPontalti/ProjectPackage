namespace Project.Web.Interfaces.Services.Security;

public interface IAccessTokenService
{
    Task<string> GetTokenAsync();
    Task SetTokenAsync(string accessToken);
    Task RemoveTokenAsync();
}