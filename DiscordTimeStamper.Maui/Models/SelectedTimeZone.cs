using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace DiscordTimeStamper.Maui.Models;

public class SelectedTimeZone : ReactiveObject
{
  [Reactive]
  public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now).AddDays(3);

  [Reactive]
  public TimeOnly Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

  [Reactive]
  public TimeZoneInfo SelectedTimeZoneInfo { get; set; }

  public IReadOnlyCollection<TimeZoneInfo> TimeZones { get; } = TimeZoneInfo.GetSystemTimeZones();
}