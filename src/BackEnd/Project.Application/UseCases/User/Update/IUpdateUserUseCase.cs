using Project.Application.Resources.Response;
using Project.Application.UseCases.User.Update.Request;

namespace Project.Application.UseCases.User.Update;

public interface IUpdateUserUseCase
{
    Task<Result> ExecuteAsync(string id, UpdateUserRequest request);
}