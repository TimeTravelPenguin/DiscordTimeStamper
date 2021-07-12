#region Title Header

// Name: Phillip Smith
// 
// Solution: DiscordTimeStamper
// Project: DiscordTimeStamper
// File Name: ApplicationShell.cs
// 
// Current Data:
// 2021-07-13 1:35 AM
// 
// Creation Date:
// 2021-07-12 10:01 PM

#endregion

namespace DiscordTimeStamper
{
  internal static class ApplicationShell
  {
    public static void Run()
    {
      var view = new MainWindowView
      {
        DataContext = new MainWindowViewModel()
      };

      view.Show();
    }
  }
}