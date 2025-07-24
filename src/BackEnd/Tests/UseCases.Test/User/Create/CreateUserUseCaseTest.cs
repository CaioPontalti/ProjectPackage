using CommonTestUtilities.Requests.User;
using Moq;
using Project.Application.Resources.Messages.User;
using Project.Application.UseCases.User.Create;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.User.Create;

public class CreateUserUseCaseTest
{
	private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

    [Fact]
    public async Task CreateUserUseCase_WhenEmailNotExists_ReturnsSuccess()
    {
        var request = CreateUserRequestBuilder.BuildSuccess();

        request.Validate();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((Project.Domain.Entities.v1.User)null);

        var result = await useCase.ExecuteAsync(request);
        Assert.Empty(result.Errors);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data.Id);
    }

    [Fact]
    public async Task CreateUserUseCase_WhenEmailAlreadyExists_ReturnsConflictError()
    {
        var request = CreateUserRequestBuilder.BuildSuccess();

        request.Validate();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new Project.Domain.Entities.v1.User());

        var result = await useCase.ExecuteAsync(request);
        Assert.NotEmpty(result.Errors);
        Assert.Contains(UserMessageValidation.UserExists, result.Errors);
        Assert.False(result.IsSuccess);
        Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
        Assert.Null(result.Data);
    }

    private CreateUserUseCase CreateUseCase()
	{
		return new CreateUserUseCase(_userRepository.Object);
    }
}