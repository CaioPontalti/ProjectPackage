using Bogus;
using Project.Application.UseCases.Account.Create.Request;

namespace CommonTestUtilities.Requests.Account;

public static class CreateAccountRequestBuilder
{
    public static CreateAccountRequest BuildSuccess()
    {
        return new Faker<CreateAccountRequest>()
            .RuleFor(a => a.Email, (f) => f.Internet.Email())
            .RuleFor(a => a.Role, (f, a) => "Admin")
            .RuleFor(a => a.AccountType, (f, a) => "Developer")
            .RuleFor(a => a.Password, (f) => f.Internet.Password(8));
    }

    public static CreateAccountRequest BuildEmailIsEmpty()
    {
        return new Faker<CreateAccountRequest>()
            .RuleFor(a => a.Email, (f, a) => string.Empty)
            .RuleFor(a => a.Role, (f, a) => "User")
            .RuleFor(a => a.AccountType, (f, a) => "Developer")
            .RuleFor(a => a.Password, (f) => f.Internet.Password(8));
    }

    public static CreateAccountRequest BuildEmailIsNull()
    {
        return new Faker<CreateAccountRequest>()
            .RuleFor(a => a.Email, (f, a) => null)
            .RuleFor(a => a.Role, (f, a) => "User")
            .RuleFor(a => a.AccountType, (f, a) => "Developer")
            .RuleFor(a => a.Password, (f) => f.Internet.Password(8));
    }

    public static CreateAccountRequest BuildEmailIsInvalid()
    {
        return new Faker<CreateAccountRequest>()
            .RuleFor(a => a.Email, (f, a) => f.Person.FirstName)
            .RuleFor(a => a.Role, (f, a) => "User")
            .RuleFor(a => a.AccountType, (f, a) => "Developer")
            .RuleFor(a => a.Password, (f) => f.Internet.Password(8));
    }

    public static CreateAccountRequest BuildRoleIsInvalid()
    {
        return new Faker<CreateAccountRequest>()
            .RuleFor(a => a.Email, (f, a) => f.Internet.Email())
            .RuleFor(a => a.Role, (f, a) => string.Empty)
            .RuleFor(a => a.AccountType, (f, a) => "Developer")
            .RuleFor(a => a.Password, (f) => f.Internet.Password(8));
    }

    public static CreateAccountRequest BuildAccountTypeIsInvalid()
    {
        return new Faker<CreateAccountRequest>()
            .RuleFor(a => a.Email, (f, a) => f.Internet.Email())
            .RuleFor(a => a.Role, (f, a) => "User")
            .RuleFor(a => a.AccountType, (f, a) => "")
            .RuleFor(a => a.Password, (f) => f.Internet.Password(8));
    }
}