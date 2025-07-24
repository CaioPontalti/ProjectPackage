using CommonTestUtilities.Requests.User;
using Project.Application.Resources.Messages.User;

namespace Validators.Test.User.Update;

public class UpdateUserValidatorTest
{
    [Fact]
    public void UpdateUserValidate_WhenRequestIsValid_ReturnsSuccess()
    {
        var request = UpdateUserRequestBuilder.BuildSuccess();

        request.Validate();

        Assert.Empty(request.Notifications);
    }

    [Fact]
    public void UpdateUserValidate_WhenNameIsEmpty_ReturnsError()
    {
        var request = UpdateUserRequestBuilder.BuildNameIsEmpty();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserNameRequerid, request.Notifications);
        Assert.Single(request.Notifications);
    }
}