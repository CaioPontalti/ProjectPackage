using Project.Web.DTOs;
using Project.Web.DTOs.Response.User;

namespace Project.Web.Interfaces.Services;

public interface IUserService
{
    Task<ApiResponse<CreateUser>> CreateUserAsync(string name, string email, string password, string role);
    Task<ApiResponse<GetAllUser>> GetAllAsync(int page, int pageSize, string search);
}