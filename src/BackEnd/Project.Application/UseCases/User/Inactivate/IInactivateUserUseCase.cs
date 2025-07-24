using Project.Application.Resources.Response;

namespace Project.Application.UseCases.User.Inactivate;

public interface IInactivateUserUseCase
{
    Task<Result> ExecuteAsync(string id);
}