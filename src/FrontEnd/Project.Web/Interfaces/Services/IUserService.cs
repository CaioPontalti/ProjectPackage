using Project.Web.DTOs;
using Project.Web.DTOs.Response.User.Create;
using Project.Web.DTOs.Response.User.GetAll;
using Project.Web.DTOs.Response.User.GetById;

namespace Project.Web.Interfaces.Services;

public interface IUserService
{
    Task<ApiResponse<CreateAccount>> CreateAsync(string email, string password, string role, string accountType);
    Task<ApiResponse<GetAllAccount>> GetAllAsync(int page, int pageSize, string search);
    Task<ApiResponse<GetByIdUser>> GetByIdAsync(string id);
}