using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarPriceDesktop.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "") => PropertyChanged?.Invoke(this, new(property));

        public void Set<T>(ref T field, T value, [CallerMemberName] string property = "")
        {
            if (Equals(field, value)) return;

            field = value;
            OnPropertyChanged(property);
        }
    }
}
