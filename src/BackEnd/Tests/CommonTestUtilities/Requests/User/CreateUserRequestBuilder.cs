using Bogus;
using Project.Application.UseCases.User.Create.Request;

namespace CommonTestUtilities.Requests.User;

public static class CreateUserRequestBuilder
{
    public static CreateUserRequest BuildSuccess()
    {
        return new Faker<CreateUserRequest>()
            .RuleFor(user => user.Name, (f) => f.Person.FirstName)
            .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Name))
            .RuleFor(user => user.Role, (f, user) => "User")
            .RuleFor(user => user.Password, (f) => f.Internet.Password(8));
    }

    public static CreateUserRequest BuildEmailIsEmpty()
    {
        return new Faker<CreateUserRequest>()
            .RuleFor(user => user.Name, (f) => f.Person.FirstName)
            .RuleFor(user => user.Email, (f, user) => string.Empty)
            .RuleFor(user => user.Role, (f, user) => "User")
            .RuleFor(user => user.Password, (f) => f.Internet.Password(8));
    }

    public static CreateUserRequest BuildEmailIsNull()
    {
        return new Faker<CreateUserRequest>()
            .RuleFor(user => user.Name, (f) => f.Person.FirstName)
            .RuleFor(user => user.Role, (f, user) => "User")
            .RuleFor(user => user.Password, (f) => f.Internet.Password(8));
    }

    public static CreateUserRequest BuildEmailIsInvalid()
    {
        return new Faker<CreateUserRequest>()
            .RuleFor(user => user.Name, (f) => f.Person.FirstName)
            .RuleFor(user => user.Role, (f, user) => "User")
            .RuleFor(user => user.Password, (f) => f.Internet.Password(8))
            .RuleFor(u => u.Email, f => "email.invalido-sem-arroba.com");
    }

    public static CreateUserRequest BuildUserEmailPasswordIsEmpty()
    {
        return new Faker<CreateUserRequest>()
            .RuleFor(user => user.Name, (f) => string.Empty)
            .RuleFor(user => user.Role, (f, user) => "User")
            .RuleFor(user => user.Password, (f) => string.Empty)
            .RuleFor(u => u.Email, f => string.Empty);
    }
}