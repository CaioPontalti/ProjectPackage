using Project.Application.Resources.Messages.Auth;
using Project.Application.Resources.Regex;
using Project.Application.Resources.Request;
using System.Text.RegularExpressions;

namespace Project.Application.UseCases.Auth.Login.Request;

public class LoginRequest : RequestBase
{
    public string Email { get; set; }
    public string Password { get; set; }

    public override void Validate()
    {
        if (string.IsNullOrEmpty(Email))
            Notifications.Add(AuthMessageValidation.AuthEmailRequerid);

        if (!Regex.IsMatch(Email, RegexPatterns.EmailPattern, RegexOptions.IgnoreCase))
            Notifications.Add(AuthMessageValidation.AuthEmailInvalid);

        if (string.IsNullOrEmpty(Password))
            Notifications.Add(AuthMessageValidation.PasswordRequerid);
    }
}