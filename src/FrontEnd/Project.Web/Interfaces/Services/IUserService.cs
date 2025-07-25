using Project.Web.DTOs;
using Project.Web.DTOs.Response.User;

namespace Project.Web.Interfaces.Services;

public interface IUserService
{
    Task<ApiResponse<CreateUser>> CreateUser(string name, string email, string password);
}