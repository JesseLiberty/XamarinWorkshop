using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Demo3.ViewModel
{
   public abstract class BaseViewModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      public void OnPropertyChanged( string propertyName )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
      }

      protected void OnPropChanged( [CallerMemberName] string propertyName = null )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
      }

      protected void SetValue<T>( ref T backingField,
         T value,
         [CallerMemberName] string propertyName = null )
      {
         if (EqualityComparer<T>.Default.Equals( backingField, value ))
         {
            return;
         }

         backingField = value;
         OnPropChanged( propertyName );
      }
   }
}