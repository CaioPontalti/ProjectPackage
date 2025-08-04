using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.GetAll.Response;
using Project.Domain.Interfaces.Repositories;

namespace Project.Application.UseCases.Account.GetAll;

public class GetAllAccountsUseCase : IGetAllAccountsUseCase
{
    private readonly IAccountRepository _accountRepository;

    public GetAllAccountsUseCase(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result<GetAllAccountsResponse>> ExecuteAsync(int page, int pageSize, string search)
    {
        var accounts = await _accountRepository.GetAllAsync(search);

        if (!accounts.Any())
        {
            return Result<GetAllAccountsResponse>.Success(System.Net.HttpStatusCode.OK,
            new GetAllAccountsResponse([], 0));
        }

        var paginatedItems = accounts.Skip(page * pageSize).Take(pageSize).ToList();

        return Result<GetAllAccountsResponse>.Success(System.Net.HttpStatusCode.OK, 
            new GetAllAccountsResponse(paginatedItems.Select(user => (Response.Account)user), accounts.Count()));
    }
}