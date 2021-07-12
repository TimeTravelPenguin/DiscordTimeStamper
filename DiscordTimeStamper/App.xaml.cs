#region Title Header

// Name: Phillip Smith
// 
// Solution: DiscordTimeStamper
// Project: DiscordTimeStamper
// File Name: App.xaml.cs
// 
// Current Data:
// 2021-07-13 1:35 AM
// 
// Creation Date:
// 2021-07-12 9:52 PM

#endregion

#region usings

using System.Windows;
using ControlzEx.Theming;

#endregion

namespace DiscordTimeStamper
{
  /// <summary>
  ///   Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      ThemeManager.Current.ChangeTheme(this, "Dark.Blue");

      ApplicationShell.Run();
    }
  }
}