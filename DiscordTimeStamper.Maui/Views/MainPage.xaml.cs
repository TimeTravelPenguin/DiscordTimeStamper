using System.Reactive.Disposables;
using DiscordTimeStamper.Maui.ViewModels;
using ReactiveUI;
using ReactiveUI.Maui;

namespace DiscordTimeStamper.Maui.Views;

public partial class MainPage : ReactiveContentPage<MainPageViewModel>
{
  public MainPage()
  {
    ViewModel = new MainPageViewModel();

    InitializeComponent();

#pragma warning disable CA1416
    this.WhenActivated(disposables =>
    {
      //ViewModel.WhenAnyValue(
      //  vm => vm.SelectedTimeZone, 
      //  vm => vm.SelectedTimeZone.Date, 
      //  (_, date) => date)
      //  .Subscribe(date => )

      // TODO: Create an observable to better mediate updates between V-VM for Date/TimeOnly bindings.
      // Or, use a DateTime, instead?

      // TODO: Need to convert
      this.Bind(ViewModel,
          vm => vm.SelectedDateTime.Date,
          v => v.DatePicker.Date)
        .DisposeWith(disposables);
    });
#pragma warning restore CA1416
  }
}