﻿using System.Reactive.Disposables;
using DiscordTimeStamper.Maui.Models;

namespace DiscordTimeStamper.Maui.ViewModels;

public class MainPageViewModel : ActivatableViewModel
{
  public SelectedTimeZone SelectedTimeZone { get; set; } = new();

  protected override void OnActivated(CompositeDisposable disposables)
  {
    
  }
}