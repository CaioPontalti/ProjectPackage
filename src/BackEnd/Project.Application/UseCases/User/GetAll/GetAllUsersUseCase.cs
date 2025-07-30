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

    public async Task<Result<GetAllAccountsResponse>> ExecuteAsync(int page, int pageSize, string search)
    {
        var users = await _userRepository.GetAllAsync(search);

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