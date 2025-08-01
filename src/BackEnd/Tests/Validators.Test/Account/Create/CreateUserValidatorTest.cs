using CommonTestUtilities.Requests.Account;
using Project.Application.Resources.Messages.Account;

namespace Validators.Test.Account.Create;

public class CreateAccountValidatorTest
{
    [Fact]
    public void CreateAccountValidate_WhenRequestIsValid_ReturnsSuccess()
    {
        var request = CreateAccountRequestBuilder.BuildSuccess();

        request.Validate();

        Assert.Empty(request.Notifications);
    }

    [Fact]
    public void CreateAccountValidate_WhenEmailIsEmpty_ReturnsError()
    {
        var request = CreateAccountRequestBuilder.BuildEmailIsEmpty();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(AccountMessageValidation.AccountEmailRequerid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateAccountValidate_WhenEmailIsNull_ReturnsError()
    {
        var request = CreateAccountRequestBuilder.BuildEmailIsNull();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(AccountMessageValidation.AccountEmailRequerid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateAccountValidate_WhenEmailIsInvalid_ReturnsError()
    {
        var request = CreateAccountRequestBuilder.BuildEmailIsInvalid();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(AccountMessageValidation.AccountEmailInvalid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateAccountValidate_WhenRolesIsInvalid_ReturnsError()
    {
        var request = CreateAccountRequestBuilder.BuildRoleIsInvalid();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(AccountMessageValidation.AccountRoleIsInvalid, request.Notifications);
        Assert.Single(request.Notifications);
    }

    [Fact]
    public void CreateAccountValidate_WhenAccountTypeIsInvalid_ReturnsError()
    {
        var request = CreateAccountRequestBuilder.BuildAccountTypeIsInvalid();

        request.Validate();

        Assert.NotEmpty(request.Notifications);
        Assert.Contains(AccountMessageValidation.AccountTypeIsInvalid, request.Notifications);
        Assert.Single(request.Notifications);
    }
}