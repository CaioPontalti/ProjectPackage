using CommonTestUtilities.Entities;
using Moq;
using Project.Application.Resources.Messages.User;
using Project.Application.UseCases.User.Inactivate;
using Project.Domain.Entities.v1;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.User.Inactivate;

public class InactivateUserUseCaseTest
{
    private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

    [Theory]
    [InlineData("idValue")]
    public async Task InactivateUserUseCase_WhenNoErrors_ReturnsSuccess(string id)
    {
        var user = UserMock.CreateUserActiveBuilder();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        var result = await useCase.ExecuteAsync(id);
        Assert.Empty(result.Errors);
        Assert.True(result.IsSuccess);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task InactivateUserUseCase_WhenIdIsEmptyOrIsNull_ReturnsBadRequestError(string id)
    {
        var user = UserMock.CreateUserActiveBuilder();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        var result = await useCase.ExecuteAsync(id);
        Assert.Single(result.Errors);
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        Assert.Contains(UserMessageValidation.IdRequerid, result.Errors);
    }

    [Theory]
    [InlineData("idValue")]
    public async Task InactivateUserUseCase_WhenUserNotFound_ReturnsNotFoundError(string id)
    {
        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((Project.Domain.Entities.v1.User)null);

        var result = await useCase.ExecuteAsync(id);
        Assert.Single(result.Errors);
        Assert.Contains(UserMessageValidation.UserNotFound, result.Errors);
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);

    }

    [Theory]
    [InlineData("idValue")]
    public async Task InactivateUserUseCase_WhenUserAlreadyInactive_ReturnsConflictError(string id)
    {
        var user = UserMock.CreateUserInactiveBuilder();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        var result = await useCase.ExecuteAsync(id);
        Assert.Single(result.Errors);
        Assert.Contains(UserMessageValidation.UserAlreadyInactive, result.Errors);
        Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
    }

    private InactivateUserUseCase CreateUseCase()
    {
        return new InactivateUserUseCase(_userRepository.Object);
    }
}