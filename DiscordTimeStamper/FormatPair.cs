using System;
using System.Globalization;

namespace DiscordTimeStamper
{
  internal struct FormatPair
  {
    public string DiscordFormat { get; init; }
    public string Value { get; init; }

    public FormatPair(string discordFormat, DateTimeOffset datetime, string dateTimeFormat)
    {
      DiscordFormat = discordFormat;
      Value = datetime.ToString(dateTimeFormat, CultureInfo.GetCultureInfo("en-US"));
    }
  }
}