using CommonTestUtilities.Requests.Auth;
using Project.Application.Resources.Messages.Auth;

namespace Validators.Test.Auth.Login;

public class LoginValidatorTest
{
    [Fact]
    public void LoginValidate_WhenRequestIsValid_ReturnsSuccess()
    {
        var request = LoginRequestBuilder.BuildSuccess();

        request.Validate();

        Assert.Empty(request.Notifications);
    }

    [Fact]
    public void LoginValidate_WhenRequestEmailIsEmpty_ReturnsError()
    {
        var request = LoginRequestBuilder.BuildEmailIsEmpty();

        request.Validate();

        Assert.Equal(2, request.Notifications.Count);
        Assert.Contains(AuthMessageValidation.AuthEmailRequerid, request.Notifications);
        Assert.Contains(AuthMessageValidation.AuthEmailInvalid, request.Notifications);
    }

    [Fact]
    public void LoginValidate_WhenRequestEmailIsInvalid_ReturnsError()
    {
        var request = LoginRequestBuilder.BuildEmailIsInvalid();

        request.Validate();

        Assert.Single(request.Notifications);
        Assert.Contains(AuthMessageValidation.AuthEmailInvalid, request.Notifications);
    }

    [Fact]
    public void LoginValidate_WhenRequestPasswordIsEmpty_ReturnsError()
    {
        var request = LoginRequestBuilder.BuildPasswordIsEmpty();

        request.Validate();

        Assert.Single(request.Notifications);
        Assert.Contains(AuthMessageValidation.PasswordRequerid, request.Notifications);
    }
}