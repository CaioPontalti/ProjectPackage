using Bogus;
using Project.Domain.Entities.v1;
namespace CommonTestUtilities.Entities;

public static class AccountMock
{
    public static Account CreateAccountActiveBuilder(string? passwordHash = null)
    {
        if (string.IsNullOrEmpty(passwordHash))
            return new Faker<Account>()
                .RuleFor(a => a.Id, f => f.Random.Guid().ToString())
                .RuleFor(a => a.PasswordHash, (f) => f.Internet.Password(8))
                .RuleFor(a => a.IsActive, f => true);

        return new Faker<Account>()
                .RuleFor(a => a.Id, f => f.Random.Guid().ToString())
                .RuleFor(a => a.PasswordHash, (f) => passwordHash)
                .RuleFor(a => a.IsActive, f => true);

    }

    public static Account CreateAccountInactiveBuilder()
    {
        return new Faker<Account>()
            .RuleFor(a => a.Id, f => f.Random.Guid().ToString())
            .RuleFor(a => a.PasswordHash, (f) => f.Internet.Password(8))
            .RuleFor(a => a.IsActive, f => false);
    }
}