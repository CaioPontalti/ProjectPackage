using Project.Application.Resources.Response;
using Project.Application.UseCases.User.Create.Request;
using Project.Application.UseCases.User.Create.Response;

namespace Project.Application.UseCases.User.Create;

public interface ICreateUserUseCase
{
    Task<Result<CreateUserResponse>> ExecuteAsync(CreateUserRequest request);
}