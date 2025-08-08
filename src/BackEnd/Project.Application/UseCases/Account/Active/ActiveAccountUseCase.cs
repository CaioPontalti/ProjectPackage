using Project.Application.Resources.Messages.Account;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.Active.Request;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Account.Active;

public class ActiveAccountUseCase : IActiveAccountUseCase
{
    private readonly IAccountRepository _accountRepository;

    public ActiveAccountUseCase(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result> ExecuteAsync(ActiveAccountRequest request)
    {
        request.Validate();

        if (request.HasNotification())
            return Result.Failure(HttpStatusCode.BadRequest, request.Notifications.ToArray());

        var accountDb = await _accountRepository.GetByIdAsync(request.Id);
        if (accountDb is null)
            return Result.Failure(HttpStatusCode.NotFound, AccountMessageValidation.AccountNotFound);

        if (accountDb.IsActive)
            return Result.Failure(HttpStatusCode.Conflict, AccountMessageValidation.AccountAlreadyActive);

        accountDb.SetActive();

        await _accountRepository.UpdateAsync(accountDb);

        return Result.Success(HttpStatusCode.OK);
    }
}