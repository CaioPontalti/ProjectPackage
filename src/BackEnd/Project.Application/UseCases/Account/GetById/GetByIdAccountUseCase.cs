using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.GetById.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Account.GetById;

public class GetByIdAccountUseCase : IGetByIdAccountUseCase
{
    private readonly IAccountRepository _accountRepository;

    public GetByIdAccountUseCase(IAccountRepository AccountRepository)
    {
        _accountRepository = AccountRepository;
    }

    public async Task<Result<GetByIdAccountResponse>> ExecuteAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            return Result<GetByIdAccountResponse>.Failure(HttpStatusCode.BadRequest, "");

        var userDb = await _accountRepository.GetByIdAsync(id);
        if (userDb is null)
            return Result<GetByIdAccountResponse>.Failure(HttpStatusCode.NotFound, "");

        return Result<GetByIdAccountResponse>.Success(HttpStatusCode.OK, new GetByIdAccountResponse((GetAll.Response.Account)userDb));
    }
}
