using CommonTestUtilities.Responses.Profile;
using Moq;
using Project.Application.Resources.Messages.Profile;
using Project.Application.UseCases.Profile.GetById;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace UseCases.Test.Profile.GetById;

public class GetByAccountIdUseCaseTest
{
    private readonly Mock<IProfileRepository> _profileRepository = new Mock<IProfileRepository>();

    [Theory]
    [InlineData("accountId")]
    public async Task GetByAccountIdUseCase_WithExistingProfile_ReturnsSuccess(string id)
    {
        var profile = GetByAccountIdResponseBuilder.GetProfileBuilser();

        var useCase = CreateUseCase();
        _profileRepository
            .Setup(rep => rep.GetByAccountId(id))
            .ReturnsAsync(profile);

        var result = await useCase.ExecuteAsync(id);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data.Profile);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task GetByAccountIdUseCase_WhenAccountIdIsEmptyOrNull_ReturnsError(string id)
    {
        var useCase = CreateUseCase();
        _profileRepository
            .Setup(rep => rep.GetByAccountId(id))
            .ReturnsAsync((Project.Domain.Entities.v1.Profile)null);

        var result = await useCase.ExecuteAsync(id);
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        Assert.False(result.IsSuccess);
        Assert.Null(result?.Data?.Profile);
        Assert.Single(result.Errors);
        Assert.Contains(ProfileMessageValidation.AccountIdRequerid, result.Errors);
    }

    [Theory]
    [InlineData("accountId")]
    public async Task GetByAccountIdUseCase_WhenProfileIsNotFound_ReturnsError(string id)
    {
        var useCase = CreateUseCase();
         _profileRepository
            .Setup(rep => rep.GetByAccountId(id))
            .ReturnsAsync((Project.Domain.Entities.v1.Profile)null);

        var result = await useCase.ExecuteAsync(id);
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        Assert.False(result.IsSuccess);
        Assert.Null(result?.Data?.Profile);
        Assert.Single(result.Errors);
        Assert.Contains(ProfileMessageValidation.AccountNotFound, result.Errors);
    }


    private GetByAccountIdUseCase CreateUseCase()
    {
        return new GetByAccountIdUseCase(_profileRepository.Object);
    }
}