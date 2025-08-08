using Project.Application.Resources.Messages.Account;
using Project.Application.Resources.Request;

namespace Project.Application.UseCases.Account.Active.Request;

public class ActiveAccountRequest : RequestBase
{
    public string Id { get; set; }

    public override void Validate()
    {
        if (string.IsNullOrEmpty(Id))
            Notifications.Add(AccountMessageValidation.IdRequerid);
    }
}