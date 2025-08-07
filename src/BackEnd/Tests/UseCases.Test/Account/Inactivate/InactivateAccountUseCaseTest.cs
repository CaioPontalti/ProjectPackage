using CommonTestUtilities.Entities;
using Moq;
using Project.Application.Resources.Messages.Account;
using Project.Application.UseCases.Account.Inactivate;
using Project.Application.UseCases.Account.Inactivate.Request;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.Account.Inactivate;

public class InactivateAccountUseCaseTest
{
    private readonly Mock<IAccountRepository> _accountRepository = new Mock<IAccountRepository>();

    [Theory]
    [InlineData("idValue")]
    public async Task InactivateAccountUseCase_WhenNoErrors_ReturnsSuccess(string id)
    {
        var account = AccountMock.CreateAccountActiveBuilder();

        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(account);

        var result = await useCase.ExecuteAsync(new InactiveAccountRequest { Id = id });
        Assert.Empty(result.Errors);
        Assert.True(result.IsSuccess);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task InactivateAccountUseCase_WhenIdIsEmptyOrIsNull_ReturnsBadRequestError(string id)
    {
        var account = AccountMock.CreateAccountActiveBuilder();

        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(account);

        var result = await useCase.ExecuteAsync(new InactiveAccountRequest { Id = id });
        Assert.Single(result.Errors);
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        Assert.Contains(AccountMessageValidation.IdRequerid, result.Errors);
    }

    [Theory]
    [InlineData("idValue")]
    public async Task InactivateAccountUseCase_WhenAccountNotFound_ReturnsNotFoundError(string id)
    {
        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((Project.Domain.Entities.v1.Account)null);

        var result = await useCase.ExecuteAsync(new InactiveAccountRequest { Id = id });
        Assert.Single(result.Errors);
        Assert.Contains(AccountMessageValidation.AccountNotFound, result.Errors);
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);

    }

    [Theory]
    [InlineData("idValue")]
    public async Task InactivateAccountUseCase_WhenAccountAlreadyInactive_ReturnsConflictError(string id)
    {
        var account = AccountMock.CreateAccountInactiveBuilder();

        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(account);

        var result = await useCase.ExecuteAsync(new InactiveAccountRequest { Id = id });
        Assert.Single(result.Errors);
        Assert.Contains(AccountMessageValidation.AccountAlreadyInactive, result.Errors);
        Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
    }

    private InactivateAccountUseCase CreateUseCase()
    {
        return new InactivateAccountUseCase(_accountRepository.Object);
    }
}