using Project.Application.Resources.Messages.Account;
using Project.Application.Resources.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Account.Inactivate;

public class InactivateAccountUseCase : IInactivateAccountUseCase
{
    private readonly IAccountRepository _userRepository;

    public InactivateAccountUseCase(IAccountRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> ExecuteAsync(string id)
    {
        if (string.IsNullOrEmpty(id?.Trim()))
            return Result.Failure(HttpStatusCode.BadRequest, AccountMessageValidation.IdRequerid);

        var userDb = await _userRepository.GetByIdAsync(id);
        if (userDb is null)
            return Result.Failure(HttpStatusCode.NotFound, AccountMessageValidation.AccountNotFound);

        if (!userDb.IsActive)
            return Result.Failure(HttpStatusCode.Conflict, AccountMessageValidation.AccountAlreadyInactive);

        userDb.SetInactive();

        await _userRepository.UpdateAsync(userDb);

        return Result.Success(HttpStatusCode.NoContent);
    }
}