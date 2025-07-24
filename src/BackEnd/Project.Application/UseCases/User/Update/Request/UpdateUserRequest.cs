using Project.Application.Resources.Messages.User;
using Project.Application.Resources.Request;

namespace Project.Application.UseCases.User.Update.Request;

public class UpdateUserRequest : RequestBase
{
    public string Name { get; set; }
    
    public override void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            Notifications.Add(UserMessageValidation.UserNameRequerid);
    }
}