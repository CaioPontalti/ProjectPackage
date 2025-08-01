using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.Create.Request;
using Project.Application.UseCases.Account.Create.Response;

namespace Project.Application.UseCases.Account.Create;

public interface ICreateAccountUseCase
{
    Task<Result<CreateAccountResponse>> ExecuteAsync(CreateAccountRequest request);
}