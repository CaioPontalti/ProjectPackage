using Project.Web.DTOs;
using Project.Web.DTOs.Response.User.GetById;

namespace Project.Web.Interfaces.Services;

public interface IProfileService
{
    Task<ApiResponse<GetByAccountId>> GetByIdAsync(string accountId);
}
