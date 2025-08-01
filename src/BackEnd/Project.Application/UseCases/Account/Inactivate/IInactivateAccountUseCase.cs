using Project.Application.Resources.Response;

namespace Project.Application.UseCases.Account.Inactivate;

public interface IInactivateAccountUseCase
{
    Task<Result> ExecuteAsync(string id);
}