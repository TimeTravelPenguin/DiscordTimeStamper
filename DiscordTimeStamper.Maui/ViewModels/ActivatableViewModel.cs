using System.Reactive.Disposables;
using ReactiveUI;

namespace DiscordTimeStamper.Maui.ViewModels;

// SRC: https://github.com/mjfreelancing/AllOverIt/blob/v6.0.0/Source/AllOverIt.ReactiveUI/ActivatableViewModel.cs
public abstract class ActivatableViewModel : ReactiveObject, IActivatableViewModel
{
  /// <inheritdoc />
  public ViewModelActivator Activator { get; } = new();

  /// <summary>Constructor.</summary>
  protected ActivatableViewModel()
  {
    // BUG:  MUST BE ANDROID >= 31
    this.WhenActivated(disposables =>
    {
      OnActivated(disposables);

      Disposable.Create(OnDeactivated).DisposeWith(disposables);
    });
  }

  // https://www.reactiveui.net/docs/guidelines/framework/dispose-your-subscriptions
  // Not all subscriptions need to be disposed. It's like events. If a component exposes an event and also subscribes to it itself,
  // it doesn't need to unsubscribe. That's because the subscription is manifested as the component having a reference to itself.
  // Same is true with Rx. If you're a VM and you e.g. WhenAnyValue against your own property, there's no need to clean that up because
  // that is manifested as the VM having a reference to itself.

  /// <summary>Override this in the concrete ViewModel to be notified when it is activated.</summary>
  /// <param name="disposables">Used to collate all the disposables to be cleaned up during deactivation.</param>
  protected abstract void OnActivated(CompositeDisposable disposables);

  /// <summary>Override this in the concrete ViewModel to be notified when it is deactivated.</summary>
  protected virtual void OnDeactivated()
  {
  }
}