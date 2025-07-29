using Project.Application.Resources.Response;
using Project.Application.UseCases.User.GetById.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.User.GetById;

public class GetByIdUserUseCase : IGetByIdUserUseCase
{
    private readonly IUserRepository _userRepository;

    public GetByIdUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetByIdUserResponse>> ExecuteAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            return Result<GetByIdUserResponse>.Failure(HttpStatusCode.BadRequest, "");

        var userDb = await _userRepository.GetByIdAsync(id);
        if (userDb is null)
            return Result<GetByIdUserResponse>.Failure(HttpStatusCode.NotFound, "");

        return Result<GetByIdUserResponse>.Success(HttpStatusCode.OK, new GetByIdUserResponse((Response.User)userDb));
    }
}
