using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.GetAll.Response;
using Project.Domain.Interfaces.Repositories;

namespace Project.Application.UseCases.Account.GetAll;

public class GetAllAccountsUseCase : IGetAllAccountsUseCase
{
    private readonly IAccountRepository _accountRepository;

    public GetAllAccountsUseCase(IAccountRepository userRepository)
    {
        _accountRepository = userRepository;
    }

    public async Task<Result<GetAllAccountsResponse>> ExecuteAsync(int page, int pageSize, string search)
    {
        var users = await _accountRepository.GetAllAsync(search);

        if (!users.Any())
        {
            return Result<GetAllAccountsResponse>.Success(System.Net.HttpStatusCode.OK,
            new GetAllAccountsResponse([], 0));
        }

        var paginatedItems = users.Skip(page * pageSize).Take(pageSize).ToList();

        return Result<GetAllAccountsResponse>.Success(System.Net.HttpStatusCode.OK, 
            new GetAllAccountsResponse(paginatedItems.Select(user => (Response.Account)user), users.Count()));
    }
}