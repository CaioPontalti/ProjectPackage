using Bogus;
using Project.Application.UseCases.Auth.Login.Request;
using Project.Application.UseCases.User.Create.Request;

namespace CommonTestUtilities.Requests.Auth
{
    public static class LoginRequestBuilder
    {
        public static LoginRequest BuildSuccess()
        {
            return new Faker<LoginRequest>()
                .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Email))
                .RuleFor(user => user.Password, (f) => f.Internet.Password(8));
        }

        public static LoginRequest BuildEmailIsEmpty()
        {
            return new Faker<LoginRequest>()
                .RuleFor(user => user.Email, (f, user) => string.Empty)
                .RuleFor(user => user.Password, (f) => f.Internet.Password(8));
        }

        public static LoginRequest BuildEmailIsInvalid()
        {
            return new Faker<LoginRequest>()
                .RuleFor(user => user.Email, (f, user) => "string.Empty")
                .RuleFor(user => user.Password, (f) => f.Internet.Password(8));
        }

        public static LoginRequest BuildPasswordIsEmpty()
        {
            return new Faker<LoginRequest>()
                .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Email))
                .RuleFor(user => user.Password, (f) => string.Empty);
        }
    }
}
