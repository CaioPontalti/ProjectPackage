namespace CommonTestUtilities.Responses.User;

public static class GetAllUsersResponseBuilder
{
    public static IEnumerable<Project.Domain.Entities.v1.Account> GetUsersLists()
    {
        var users = new List<Project.Domain.Entities.v1.Account>
        {
            new Project.Domain.Entities.v1.Account(),
            new Project.Domain.Entities.v1.Account()
        };

        return users;
    }
}