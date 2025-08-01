using CommonTestUtilities.Requests.Account;
using Moq;
using Project.Application.Resources.Messages.Account;
using Project.Application.UseCases.Account.Create;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.Account.Create;

public class CreateAccountUseCaseTest
{
	private readonly Mock<IAccountRepository> _accountRepository = new Mock<IAccountRepository>();

    [Fact]
    public async Task CreateAccountUseCase_WhenEmailNotExists_ReturnsSuccess()
    {
        var request = CreateAccountRequestBuilder.BuildSuccess();

        request.Validate();

        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((Project.Domain.Entities.v1.Account)null);

        var result = await useCase.ExecuteAsync(request);
        Assert.Empty(result.Errors);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data.Id);
    }

    [Fact]
    public async Task CreateAccountUseCase_WhenEmailAlreadyExists_ReturnsConflictError()
    {
        var request = CreateAccountRequestBuilder.BuildSuccess();

        request.Validate();

        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new Project.Domain.Entities.v1.Account());

        var result = await useCase.ExecuteAsync(request);
        Assert.NotEmpty(result.Errors);
        Assert.Contains(AccountMessageValidation.AccountExists, result.Errors);
        Assert.False(result.IsSuccess);
        Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
        Assert.Null(result.Data);
    }

    private CreateAccountUseCase CreateUseCase()
	{
		return new CreateAccountUseCase(_accountRepository.Object);
    }
}