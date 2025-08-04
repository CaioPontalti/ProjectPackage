using CommonTestUtilities.Entities;

namespace CommonTestUtilities.Responses.Profile;

public static class GetByProfileIdResponseBuilder
{
    public static Project.Domain.Entities.v1.Profile GetProfileBuilser()
    {
        return ProfileMock.CreateProfileBuilder();
    }
}