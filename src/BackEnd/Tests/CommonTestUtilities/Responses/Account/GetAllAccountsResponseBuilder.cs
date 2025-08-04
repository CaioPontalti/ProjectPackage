using CommonTestUtilities.Entities;

namespace CommonTestUtilities.Responses.User;

public static class GetAllAccountsResponseBuilder
{
    public static IEnumerable<Project.Domain.Entities.v1.Account> GetAccountsList()
    {
        var account1 = AccountMock.CreateAccountActiveBuilder();
        var account2 = AccountMock.CreateAccountActiveBuilder();

        var accounts = new List<Project.Domain.Entities.v1.Account>
        {
            account1,
            account2
        };

        return accounts;
    }
}