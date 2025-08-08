using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.Active.Request;

namespace Project.Application.UseCases.Account.Active;

public interface IActiveAccountUseCase
{
    Task<Result> ExecuteAsync(ActiveAccountRequest request);
}
