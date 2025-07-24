namespace CommonTestUtilities.Responses.User;

public static class GetAllUsersResponseBuilder
{
    public static IEnumerable<Project.Domain.Entities.v1.User> GetUsersLists()
    {
        var users = new List<Project.Domain.Entities.v1.User>
        {
            new Project.Domain.Entities.v1.User(),
            new Project.Domain.Entities.v1.User()
        };

        return users;
    }
}