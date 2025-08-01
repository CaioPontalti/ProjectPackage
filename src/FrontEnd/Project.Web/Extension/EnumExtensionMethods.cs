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

    public static string GetEnumDescriptionFromString<TEnum>(this string enumValue)
        where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(enumValue, ignoreCase: true, out var result))
        {
            var field = typeof(TEnum).GetField(result.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? result.ToString();
        }

        return $"Valor '{enumValue}' não encontrado no enum {typeof(TEnum).Name}.";
    }
}
