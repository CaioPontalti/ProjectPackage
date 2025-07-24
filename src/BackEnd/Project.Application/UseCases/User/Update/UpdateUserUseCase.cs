using Project.Application.Resources.Messages.User;
using Project.Application.Resources.Response;
using Project.Application.UseCases.User.Update.Request;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.User.Update;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public UpdateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> ExecuteAsync(string id, UpdateUserRequest request)
    {
        request.Validate();

        if (string.IsNullOrEmpty(id?.Trim()))
            return Result.Failure(HttpStatusCode.BadRequest, UserMessageValidation.IdRequerid);

        if (request.HasNotification())
            return Result.Failure(HttpStatusCode.BadRequest, request.Notifications.ToArray());

        var userDb = await _userRepository.GetByIdAsync(id);
        if (userDb is null)
            return Result.Failure(HttpStatusCode.NotFound, UserMessageValidation.UserNotFound);

        userDb.Update(request.Name);

        await _userRepository.UpdateAsync(userDb);

        return Result.Success(HttpStatusCode.NoContent);
    }
}