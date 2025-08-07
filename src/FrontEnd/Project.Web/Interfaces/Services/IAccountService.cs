using Project.Web.DTOs;
using Project.Web.DTOs.Response.Account.Create;
using Project.Web.DTOs.Response.Account.GetAll;

namespace Project.Web.Interfaces.Services;

public interface IAccountService
{
    Task<ApiResponse<CreateAccount>> CreateAsync(string email, string password, string role, string accountType);
    Task<ApiResponse<GetAllAccount>> GetAllAsync(int page, int pageSize, string search);
    Task<ApiResponse> InactiveAccountAsync(string id);
}