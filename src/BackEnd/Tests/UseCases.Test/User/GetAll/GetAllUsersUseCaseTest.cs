using CommonTestUtilities.Responses.User;
using Moq;
using Project.Application.UseCases.User.GetAll;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.User.GetAll;

public class GetAllUsersUseCaseTest
{
    private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

    [Theory]
    [InlineData(0, 2, "")]
    public async Task GetAllUsersUseCase_WithExistingUsers_ReturnsListOfUsers(int page, int pageSize, string search)
    {
        var usersList = GetAllUsersResponseBuilder.GetUsersLists();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetAllAsync(""))
            .ReturnsAsync(usersList);

        var result = await useCase.ExecuteAsync(page, pageSize, search);
        Assert.NotEmpty(result.Data.Accunts);
        Assert.True(result.IsSuccess);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Theory]
    [InlineData(0, 2, "")]
    public async Task GetAllUsersUseCase_WhenNoUsersExist_ReturnsEmptyList(int page, int pageSize, string search)
    {
        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetAllAsync(""))
            .ReturnsAsync(Enumerable.Empty<Project.Domain.Entities.v1.User>);

        var result = await useCase.ExecuteAsync(page, pageSize, search);
        Assert.Empty(result.Data.Accunts);
        Assert.True(result.IsSuccess);
    }

    private GetAllUsersUseCase CreateUseCase()
    {
        return new GetAllUsersUseCase(_userRepository.Object);
    }
}