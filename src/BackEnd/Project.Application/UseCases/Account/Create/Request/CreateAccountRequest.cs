using Project.Application.Resources.Messages.Account;
using Project.Application.Resources.Regex;
using Project.Application.Resources.Request;
using Project.Domain.Enums;
using Project.Domain.Extensions;
using System.Text.RegularExpressions;

namespace Project.Application.UseCases.Account.Create.Request;

public class CreateAccountRequest : RequestBase
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string AccountType { get; set; }
    public string Role { get; set; }

    public override void Validate()
    {
        if (string.IsNullOrEmpty(Email))
        {
            Notifications.Add(AccountMessageValidation.AccountEmailRequerid);
            return;
        }

        if (!Regex.IsMatch(Email, RegexPatterns.EmailPattern, RegexOptions.IgnoreCase))
            Notifications.Add(AccountMessageValidation.AccountEmailInvalid);

        if (string.IsNullOrEmpty(Password))
            Notifications.Add(AccountMessageValidation.AccountPasswordRequired);

        if (!AccountType.IsValidEnum<AccountTypes>())
            Notifications.Add(AccountMessageValidation.AccountTypeInvalid);

        if (!Role.IsValidEnum<Roles>())
            Notifications.Add(AccountMessageValidation.AccountRoleInvalid);
    }
}