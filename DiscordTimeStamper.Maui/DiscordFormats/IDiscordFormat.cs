namespace DiscordTimeStamper.Maui.DiscordFormats;

internal interface IDiscordFormat
{
  string TimeToTag(TimeZoneInfo tzInfo);
  string TimeToString(TimeZoneInfo tzInfo);
}