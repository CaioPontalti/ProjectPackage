using Project.Application.DTOs.User.GetAll;
using Project.Application.Resources.Response;
using Project.Application.UseCases.User.GetUsers.Response;
using Project.Domain.Interfaces.Repositories;

namespace Project.Application.UseCases.User.GetAll;

public class GetAllUsersUseCase : IGetAllUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetAllUsersResponse>> ExecuteAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return Result<GetAllUsersResponse>.Success(System.Net.HttpStatusCode.OK, 
            new GetAllUsersResponse(users.Select(user => (UserResponse)user)));
    }
}