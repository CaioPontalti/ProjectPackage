using Project.Application.Resources.Messages.User;
using Project.Application.Resources.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.User.Inactivate;

public class InactivateUserUseCase : IInactivateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public InactivateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> ExecuteAsync(string id)
    {
        if (string.IsNullOrEmpty(id?.Trim()))
            return Result.Failure(HttpStatusCode.BadRequest, UserMessageValidation.IdRequerid);

        var userDb = await _userRepository.GetByIdAsync(id);
        if (userDb is null)
            return Result.Failure(HttpStatusCode.NotFound, UserMessageValidation.UserNotFound);

        if (!userDb.IsActive)
            return Result.Failure(HttpStatusCode.Conflict, UserMessageValidation.UserAlreadyInactive);

        userDb.SetInactive();

        await _userRepository.UpdateAsync(userDb);

        return Result.Success(HttpStatusCode.NoContent);
    }
}