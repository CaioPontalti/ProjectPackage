using CommonTestUtilities.Requests.Profile;
using Project.Application.Resources.Messages.Profile;

namespace Validators.Test.Profile.Update;

public class UpdateValidatorTest
{
    [Fact]
    public void UpdateValidate_WhenRequestIsValid_ReturnsSuccess()
    {
        var request = UpdateProfileRequestBuilder.BuildSuccess();

        request.Validate();

        Assert.Empty(request.Notifications);
    }

    [Fact]
    public void UpdateValidate_WhenRequestIdIsEmpty_ReturnsError()
    {
        var request = UpdateProfileRequestBuilder.BuildIdIsEmpty();

        request.Validate();

        Assert.Single(request.Notifications);
        Assert.Contains(ProfileMessageValidation.IdRequerid, request.Notifications);
    }

    [Fact]
    public void UpdateValidate_WhenRequestAddressIsInvalid_ReturnsError()
    {
        var request = UpdateProfileRequestBuilder.BuildAddressIsInvalid();

        request.Validate();

        Assert.Single(request.Notifications);
        Assert.Contains(ProfileMessageValidation.AddressInvalid, request.Notifications);
    }
}
