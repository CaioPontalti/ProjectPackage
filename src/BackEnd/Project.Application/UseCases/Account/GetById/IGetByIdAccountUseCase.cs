using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.GetById.Response;

namespace Project.Application.UseCases.Account.GetById;

public interface IGetByIdAccountUseCase
{
    Task<Result<GetByIdAccountResponse>> ExecuteAsync(string id);
}
