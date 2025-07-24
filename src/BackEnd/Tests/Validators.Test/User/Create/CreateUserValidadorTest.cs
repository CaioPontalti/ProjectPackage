using CommonTestUtilities.Requests.User;
using Project.Application.Resources.Messages.User;

namespace Validators.Test.User.Create;

public class CreateUserValidadorTest
{
    [Fact]
    public void CreateUserUseCase_WhenDataIsValid_ReturnsSuccess()
    {
        var request = CreateUserRequestBuilder.BuildSuccess();

        request.Validate();

        Assert.Empty(request.Notifications);
    }

    [Fact]
    public void CreateUserUseCase_WhenEmailIsEmpty_ReturnsError()
    {
        var request = CreateUserRequestBuilder.BuildEmailIsEmpty();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserEmailRequerid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateUserUseCase_WhenEmailIsNull_ReturnsError()
    {
        var request = CreateUserRequestBuilder.BuildEmailIsNull();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserEmailRequerid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateUserUseCase_WhenEmailIsInvalid_ReturnsError()
    {
        var request = CreateUserRequestBuilder.BuildEmailIsInvalid();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(UserMessageValidation.UserEmailInvalid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateUserUseCase_WhenNameEmailPasswordAreEmpty_ReturnsErrors()
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