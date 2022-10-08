using System.Reactive.Disposables;
using DiscordTimeStamper.Maui.Models;

namespace DiscordTimeStamper.Maui.ViewModels;

public class MainPageViewModel : ActivatableViewModel
{
  public SelectedDateTime SelectedDateTime { get; set; } = new();

  protected override void OnActivated(CompositeDisposable disposables)
  {
    
  }
}