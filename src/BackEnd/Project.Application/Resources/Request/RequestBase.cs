using System.Text.Json.Serialization;

namespace Project.Application.Resources.Request;

public abstract class RequestBase
{
    [JsonIgnore]
    public List<string> Notifications { get; set; } = [];

    public abstract void Validate();
    public bool HasNotification() => Notifications.Count != 0;
}