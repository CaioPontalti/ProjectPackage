using CommonTestUtilities.Responses.User;
using Moq;
using Project.Application.UseCases.Account.GetAll;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.Account.GetAll;

public class GetAllAccountsUseCaseTest
{
    private readonly Mock<IAccountRepository> _accountRepository = new Mock<IAccountRepository>();

    [Theory]
    [InlineData(0, 2, "")]
    public async Task GetAllAccountsUseCase_WithExistingAccounts_ReturnsListOfAccounts(int page, int pageSize, string search)
    {
        var accountsList = GetAllUsersResponseBuilder.GetUsersLists();

        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetAllAsync(search))
            .ReturnsAsync(accountsList);

        var result = await useCase.ExecuteAsync(page, pageSize, search);
        Assert.NotEmpty(result.Data.Accounts);
        Assert.True(result.IsSuccess);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Theory]
    [InlineData(0, 2, "")]
    public async Task GetAllAccountsUseCase_WhenNoAccountsExist_ReturnsEmptyList(int page, int pageSize, string search)
    {
        var useCase = CreateUseCase();
        _accountRepository
            .Setup(rep => rep.GetAllAsync(search))
            .ReturnsAsync(Enumerable.Empty<Project.Domain.Entities.v1.Account>);

        var result = await useCase.ExecuteAsync(page, pageSize, search);
        Assert.Empty(result.Data.Accounts);
        Assert.True(result.IsSuccess);
    }

    private GetAllAccountsUseCase CreateUseCase()
    {
        return new GetAllAccountsUseCase(_accountRepository.Object);
    }
}