using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.GetAll.Response;

namespace Project.Application.UseCases.Account.GetAll;

public interface IGetAllAccountsUseCase
{
    Task<Result<GetAllAccountsResponse>> ExecuteAsync(int page, int pageSize, string search);
}