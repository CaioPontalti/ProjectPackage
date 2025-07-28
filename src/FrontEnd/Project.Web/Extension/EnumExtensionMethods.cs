using System.ComponentModel;
using System.Reflection;

namespace Project.Web.Extension;

public static class EnumExtensionMethods
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? value.ToString();
    }
}
