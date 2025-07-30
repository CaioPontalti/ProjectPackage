using Project.Web.DTOs;
using Project.Web.DTOs.Response.User.Create;
using Project.Web.DTOs.Response.User.GetAll;
using Project.Web.DTOs.Response.User.GetById;

namespace Project.Web.Interfaces.Services;

public interface IUserService
{
    Task<ApiResponse<CreateUser>> CreateAsync(string name, string email, string password, string role);
    Task<ApiResponse<GetAllUser>> GetAllAsync(int page, int pageSize, string search);
    Task<ApiResponse<GetByIdUser>> GetByIdAsync(string id);
}