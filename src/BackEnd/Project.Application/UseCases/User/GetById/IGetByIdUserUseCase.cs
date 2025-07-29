using Project.Application.Resources.Response;
using Project.Application.UseCases.User.GetById.Response;

namespace Project.Application.UseCases.User.GetById;

public interface IGetByIdUserUseCase
{
    Task<Result<GetByIdUserResponse>> ExecuteAsync(string id);
}
