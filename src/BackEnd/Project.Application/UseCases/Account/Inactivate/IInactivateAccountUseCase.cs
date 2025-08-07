using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.Inactivate.Request;

namespace Project.Application.UseCases.Account.Inactivate;

public interface IInactivateAccountUseCase
{
    Task<Result> ExecuteAsync(InactiveAccountRequest request);
}