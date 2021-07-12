#region Title Header

// Name: Phillip Smith
// 
// Solution: DiscordTimeStamper
// Project: DiscordTimeStamper
// File Name: PropertyChangedBase.cs
// 
// Current Data:
// 2021-07-13 1:35 AM
// 
// Creation Date:
// 2021-07-12 10:18 PM

#endregion

#region usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace DiscordTimeStamper
{
  /// <summary>
  ///   Base class to implement INPC
  /// </summary>
  public abstract class PropertyChangedBase : INotifyPropertyChanged
  {
    /// <summary>
    ///   The property changed event handler
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    ///   Raises property changed event
    /// </summary>
    /// <param name="propertyName"></param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    ///   Sets the value of a property and raises event changed if and only if the value is different
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field">The field to set the value of</param>
    /// <param name="value">The new value</param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
      if (string.IsNullOrEmpty(propertyName))
      {
        throw new ArgumentNullException(nameof(propertyName));
      }

      if (EqualityComparer<T>.Default.Equals(field, value))
      {
        return false;
      }

      field = value;
      OnPropertyChanged(propertyName);

      return true;
    }
  }
}