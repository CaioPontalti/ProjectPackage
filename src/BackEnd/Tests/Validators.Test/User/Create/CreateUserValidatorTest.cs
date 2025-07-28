using CommonTestUtilities.Requests.User;
using Project.Application.Resources.Messages.User;

namespace Validators.Test.User.Create;

public class CreateUserValidatorTest
{
    [Fact]
    public void CreateUserValidate_WhenRequestIsValid_ReturnsSuccess()
    {
        var request = CreateUserRequestBuilder.BuildSuccess();

        request.Validate();

        Assert.Empty(request.Notifications);
    }

    [Fact]
    public void CreateUserValidate_WhenEmailIsEmpty_ReturnsError()
    {
        var request = CreateUserRequestBuilder.BuildEmailIsEmpty();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserEmailRequerid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateUserValidate_WhenEmailIsNull_ReturnsError()
    {
        var request = CreateUserRequestBuilder.BuildEmailIsNull();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserEmailRequerid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateUserValidate_WhenEmailIsInvalid_ReturnsError()
    {
        var request = CreateUserRequestBuilder.BuildEmailIsInvalid();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserEmailInvalid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateUserValidate_WhenRolesIsEmpty_ReturnsError()
    {
        var request = CreateUserRequestBuilder.BuildRoleIsEmpty();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserRoleRequired, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateUserValidate_WhenNameEmailPasswordAreEmpty_ReturnsErrors()
    {
        var request = CreateUserRequestBuilder.BuildUserEmailPasswordIsEmpty();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserNameRequerid, request.Notifications);
        Assert.Contains(UserMessageValidation.UserEmailRequerid, request.Notifications);
        Assert.Contains(UserMessageValidation.UserPasswordRequired, request.Notifications);
        Assert.Equal(3, request.Notifications.Count);
    }
}