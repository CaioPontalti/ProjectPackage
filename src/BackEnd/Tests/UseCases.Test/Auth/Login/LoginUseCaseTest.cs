using CommonTestUtilities.Entities;
using CommonTestUtilities.Requests.Auth;
using Moq;
using Project.Application.UseCases.Auth.Login;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;
using System.Net;

namespace UseCases.Test.Auth.Login;

public class LoginUseCaseTest
{
    private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
    private readonly Mock<IAuthService> _authService = new Mock<IAuthService>();

    [Fact]
    public async Task LoginUseCase_WhenLoginIsSuccess_ReturnsSuccess()
    {
        var request = LoginRequestBuilder.BuildSuccess();

        request.Validate();

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = UserMock.CreateUserActiveBuilder(hashedPassword);
        var token = new Project.Domain.ValueObjects.Auth.Token { AcccessToken = "ceruivhuifhviuthiuthvrt" };

        var useCase = CreateUseCase();
        _userRepository
            .Setup(rep => rep.GetByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _authService
            .Setup(auth => auth.GenerateToken(user))
            .Returns(token);

        var result = await useCase.ExecuteAsync(request);
        Assert.Empty(result.Errors);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data.User);
        Assert.NotNull(result.Data.Token);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }




    private LoginUseCase CreateUseCase()
    {
        return new LoginUseCase(_userRepository.Object, _authService.Object);
    }
}