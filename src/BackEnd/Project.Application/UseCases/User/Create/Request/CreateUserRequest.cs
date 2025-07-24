using Project.Application.Resources.Messages.User;
using Project.Application.Resources.Regex;
using Project.Application.Resources.Request;
using System.Text.RegularExpressions;

namespace Project.Application.UseCases.User.Create.Request;

public class CreateUserRequest : RequestBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public override void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            Notifications.Add(UserMessageValidation.UserNameRequerid);      

        if (string.IsNullOrEmpty(Password))
            Notifications.Add(UserMessageValidation.UserPasswordRequired);

        if (string.IsNullOrEmpty(Email))
        {
            Notifications.Add(UserMessageValidation.UserEmailRequerid);
            return;
        }           

        if (!Regex.IsMatch(Email, RegexPatterns.EmailPattern, RegexOptions.IgnoreCase))
            Notifications.Add(UserMessageValidation.UserEmailInvalid);
    }
}