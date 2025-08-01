using System.ComponentModel;

namespace Project.Domain.Extensions;

public static class StringExtensions
{
    public static bool IsValidEnum<TEnum>(this string value) where TEnum : struct, Enum
    {
        return Enum.TryParse<TEnum>(value, ignoreCase: true, out var parsedValue)
               && Enum.IsDefined(typeof(TEnum), parsedValue);
    }

    public static bool IsValidEnumDescription<TEnum>(this string description) where TEnum : Enum
    {
        var type = typeof(TEnum);

        foreach (var field in type.GetFields())
        {
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                 .Cast<DescriptionAttribute>()
                                 .FirstOrDefault();

            if (attribute != null && attribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }
}