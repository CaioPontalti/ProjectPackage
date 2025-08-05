namespace Project.Domain.Extensions;

public static class DateTimeExtensions
{
    public static DateTime? NormalizeDateTimeForMongo(this DateTime? date)
    {
        if (date is null)
            return null;

        var fuso = TimeZoneInfo.Local;
        var offset = fuso.GetUtcOffset(date.Value);

        return date.Value.Add(offset);
    }
}