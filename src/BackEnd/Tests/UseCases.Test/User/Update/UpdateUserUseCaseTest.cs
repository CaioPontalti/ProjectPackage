using CommonTestUtilities.Requests.User;
using Moq;
using Project.Application.Resources.Messages.User;
using Project.Application.UseCases.User.Update;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.User.Update;

public class UpdateUserUseCaseTest
{
    private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

    [Theory]
    [InlineData("idValue")]
    public async Task UpdateUserUseCase_WhenUserExists_ReturnsSuccess(string id)
    {
        var request = UpdateUserRequestBuilder.BuildSuccess();

        request.Validate();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new Project.Domain.Entities.v1.User());

        var result = await useCase.ExecuteAsync(id, request);
        Assert.Empty(result.Errors);
        Assert.True(result.IsSuccess);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task UpdateUserUseCase_WhenIdIsEmptyOrIsNull_ReturnsError(string id)
    {
        var request = UpdateUserRequestBuilder.BuildSuccess();

        request.Validate();

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((Project.Domain.Entities.v1.User)null);

        var result = await useCase.ExecuteAsync(id, request);
        Assert.False(result.IsSuccess);
        Assert.Contains(UserMessageValidation.IdRequerid, result.Errors);
        Assert.Single(result.Errors);
    }

    [Theory]
    [InlineData("idValue")]
    public async Task UpdateUserUseCase_WhenUserDoesNotExist_ReturnsUserNotFoundError(string id)
    {
        var request = UpdateUserRequestBuilder.BuildSuccess();

        request.Validate(); 

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByIdAsync(id))
            .ReturnsAsync((Project.Domain.Entities.v1.User)null);

        var result = await useCase.ExecuteAsync(id, request);
        Assert.False(result.IsSuccess);
        Assert.Contains(UserMessageValidation.UserNotFound, result.Errors);
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        Assert.Single(result.Errors);
    }

    private UpdateUserUseCase CreateUseCase()
    {
        return new UpdateUserUseCase(_userRepository.Object);
    }
}