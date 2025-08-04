using Project.Application.Resources.Messages.Account;
using Project.Application.Resources.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Account.Inactivate;

public class InactivateAccountUseCase : IInactivateAccountUseCase
{
    private readonly IAccountRepository _accountRepository;

    public InactivateAccountUseCase(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result> ExecuteAsync(string id)
    {
        if (string.IsNullOrEmpty(id?.Trim()))
            return Result.Failure(HttpStatusCode.BadRequest, AccountMessageValidation.IdRequerid);

        var accountDb = await _accountRepository.GetByIdAsync(id);
        if (accountDb is null)
            return Result.Failure(HttpStatusCode.NotFound, AccountMessageValidation.AccountNotFound);

        if (!accountDb.IsActive)
            return Result.Failure(HttpStatusCode.Conflict, AccountMessageValidation.AccountAlreadyInactive);

        accountDb.SetInactive();

        await _accountRepository.UpdateAsync(accountDb);

        return Result.Success(HttpStatusCode.NoContent);
    }
}