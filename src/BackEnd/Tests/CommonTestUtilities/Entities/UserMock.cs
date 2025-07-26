using Bogus;
using Project.Domain.Entities.v1;
namespace CommonTestUtilities.Entities;

public static class UserMock
{
    public static User CreateUserActiveBuilder(string? passwordHash = null)
    {
        if (string.IsNullOrEmpty(passwordHash))
            return new Faker<User>()
                .RuleFor(user => user.Id, f => f.Random.Guid().ToString())
                .RuleFor(user => user.Name, (f) => f.Person.FirstName)
                .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Name))
                .RuleFor(user => user.PasswordHash, (f) => f.Internet.Password(8))
                .RuleFor(user => user.IsActive, f => true);

        return new Faker<User>()
                .RuleFor(user => user.Id, f => f.Random.Guid().ToString())
                .RuleFor(user => user.Name, (f) => f.Person.FirstName)
                .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Name))
                .RuleFor(user => user.PasswordHash, (f) => passwordHash)
                .RuleFor(user => user.IsActive, f => true);

    }

    public static User CreateUserInactiveBuilder()
    {
        return new Faker<User>()
            .RuleFor(user => user.Id, f => f.Random.Guid().ToString())
            .RuleFor(user => user.Name, (f) => f.Person.FirstName)
            .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Name))
            .RuleFor(user => user.PasswordHash, (f) => f.Internet.Password(8))
            .RuleFor(user => user.IsActive, f => false);
    }
}