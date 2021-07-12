#region Title Header

// Name: Phillip Smith
// 
// Solution: DiscordTimeStamper
// Project: DiscordTimeStamper
// File Name: MainWindowViewModel.cs
// 
// Current Data:
// 2021-07-13 1:35 AM
// 
// Creation Date:
// 2021-07-12 10:02 PM

#endregion

#region usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using Microsoft.Xaml.Behaviors.Core;

#endregion

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

  internal class MainWindowViewModel : PropertyChangedBase
  {
    private DateTime _dateTime = DateTime.Now;
    private ObservableCollection<FormatPair> _generatedFormats = new();
    private TimeZoneInfo _selectedTimeZone = TimeZoneInfo.Local;
    public ActionCommand DataGridDoubleClickCommand { get; }

    public DateTime DateTime
    {
      get => _dateTime;
      set => SetValue(ref _dateTime, value);
    }

    public IReadOnlyCollection<TimeZoneInfo> TimeZones { get; } = TimeZoneInfo.GetSystemTimeZones();

    public TimeZoneInfo SelectedTimeZone
    {
      get => _selectedTimeZone;
      set => SetValue(ref _selectedTimeZone, value);
    }

    public ObservableCollection<FormatPair> GeneratedFormats
    {
      get => _generatedFormats;
      set => SetValue(ref _generatedFormats, value);
    }

    public FormatPair? SelectedDataGridItem { get; set; }

    public MainWindowViewModel()
    {
      PropertyChanged += UpdateFormats;

      DataGridDoubleClickCommand = new ActionCommand(CopyToClipboard);

      UpdateFormats(this, new PropertyChangedEventArgs(nameof(GetType)));
    }

    private void CopyToClipboard()
    {
      if (SelectedDataGridItem is not null)
      {
        Clipboard.SetText(((FormatPair) SelectedDataGridItem).DiscordFormat);
      }
    }

    private void UpdateFormats(object? sender, PropertyChangedEventArgs e)
    {
      GeneratedFormats.Clear();

      DateTimeOffset formattedTime;
      try
      {
        formattedTime = new DateTimeOffset(DateTime.Year, DateTime.Month, DateTime.Day, DateTime.Hour,
          DateTime.Minute, DateTime.Second, SelectedTimeZone.BaseUtcOffset);
      }
      catch (Exception err)
      {
        MessageBox.Show("An error has occurred:" + Environment.NewLine + err.Message, "Error...");
        throw;
      }

      var discordFormat = $"<t:{formattedTime.ToUnixTimeSeconds()}:{{0}}>";
      GeneratedFormats.Add(new FormatPair(string.Format(discordFormat, "d"), formattedTime, "MM/dd/yyyy"));
      GeneratedFormats.Add(new FormatPair(string.Format(discordFormat, "f"), formattedTime, "MMMM dd, yyyy h:mm tt"));
      GeneratedFormats.Add(new FormatPair(string.Format(discordFormat, "t"), formattedTime, "h:mm tt"));
      GeneratedFormats.Add(new FormatPair(string.Format(discordFormat, "D"), formattedTime, "MMMM dd, yyyy"));
      GeneratedFormats.Add(new FormatPair(string.Format(discordFormat, "F"), formattedTime, "dddd, MMMM dd, yyyy h:mm tt"));
      GeneratedFormats.Add(new FormatPair {DiscordFormat = string.Format(discordFormat, "R"), Value = "<Time remaining since/until>"});
      GeneratedFormats.Add(new FormatPair(string.Format(discordFormat, "T"), formattedTime, "h:mm:ss tt"));
    }
  }
}