using Project.Web.DTOs;
using Project.Web.DTOs.Response.Auth;

namespace Project.Web.Interfaces.Services;

public interface IAuthService
{
    Task<ApiResponse<Login>> LoginAsync(string userName, string password);
}