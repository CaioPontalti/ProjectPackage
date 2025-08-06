using Project.Web.DTOs;
using Project.Web.DTOs.Response.Profile.GetByAccountId;

namespace Project.Web.Interfaces.Services;

public interface IProfileService
{
    Task<ApiResponse<GetByAccountId>> GetByIdAsync(string accountId);
    Task<ApiResponse> UpdateAsync(Profile profile);
}