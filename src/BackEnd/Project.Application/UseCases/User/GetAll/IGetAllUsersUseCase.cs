using Project.Application.Resources.Response;
using Project.Application.UseCases.User.GetUsers.Response;

namespace Project.Application.UseCases.User.GetAll
{
    public interface IGetAllUsersUseCase
    {
        Task<Result<GetAllUsersResponse>> ExecuteAsync();
    }
}