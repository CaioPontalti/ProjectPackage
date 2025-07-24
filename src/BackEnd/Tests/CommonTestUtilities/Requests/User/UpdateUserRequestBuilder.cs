using Bogus;
using Project.Application.UseCases.User.Update.Request;

namespace CommonTestUtilities.Requests.User;

public static class UpdateUserRequestBuilder
{
    public static UpdateUserRequest BuildSuccess()
    {
        return new Faker<UpdateUserRequest>()
            .RuleFor(user => user.Name, (f) => f.Person.FirstName);
    }

    public static UpdateUserRequest BuildNameIsEmpty()
    {
        return new Faker<UpdateUserRequest>()
            .RuleFor(user => user.Name, (f) => string.Empty);
    }
}