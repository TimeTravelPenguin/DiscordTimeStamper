using System.Globalization;

namespace DiscordTimeStamper.Maui.DiscordFormats;

internal class DiscordFormat : IDiscordFormat
{
  private readonly DateTimeOffset _dateTimeOffset;
  private readonly string _dateTimeFormat;

  public string TimeToTag(TimeZoneInfo tzInfo)
  {
    return $"<t:{_dateTimeOffset.ToUnixTimeSeconds()}:{{0}}>";
  }

  public string TimeToString(TimeZoneInfo tzInfo)
  {
    return _dateTimeOffset.ToString(_dateTimeFormat, CultureInfo.GetCultureInfo("en-US"));
  }

  public DiscordFormat(DateTime dt, TimeZoneInfo tzInfo, string dtFormat)
  {
    _dateTimeFormat = dtFormat;

    _dateTimeOffset = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour,
      dt.Minute, dt.Second, tzInfo.GetUtcOffset(dt));
  }
}