using CommonTestUtilities.Responses.Profile;
using Moq;
using Project.Application.UseCases.Profile.GetById;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.Profile.GetById;

public class GetByProfileIdUseCaseTest
{
    private readonly Mock<IProfileRepository> _profileRepository = new Mock<IProfileRepository>();

    [Theory]
    [InlineData("profileId")]
    public async Task GetByProfileIdUseCase_WithExistingProfile_ReturnsSuccess(string id)
    {
        var profile = GetByProfileIdResponseBuilder.GetProfileBuilser();

        var useCase = CreateUseCase();
        _profileRepository
            .Setup(rep => rep.GetByAccountId(id))
            .ReturnsAsync(profile);

        var result = await useCase.ExecuteAsync(id);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data.Profile);
    }


    private GetByAccountIdUseCase CreateUseCase()
    {
        return new GetByAccountIdUseCase(_profileRepository.Object);
    }
}
