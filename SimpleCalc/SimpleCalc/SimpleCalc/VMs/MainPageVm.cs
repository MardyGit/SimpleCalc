using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SimpleCalc.VMs
{
    public class MainPageVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _currentValue = "0";
        private string _errorMessage;

        public string CurrentValue
        {
            get => _currentValue;
            set => HasPropertyChanged(value, ref _currentValue);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => HasPropertyChanged(value, ref _errorMessage);
        }

        protected bool HasPropertyChanged<T>(T newValue, ref T currentValue, [CallerMemberName] string propertyName = "")
        {
            if (Equals(newValue, currentValue))
            {
                return false;
            }

            currentValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            Device.BeginInvokeOnMainThread(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
        }

        public void NumberTapHandler(string value)
        {
            if (CurrentValue.Length == 10)
            {
                return;
            }

            var newValue = CurrentValue;

            if (CurrentValue == "0" || (CurrentValue == "0" && value == "0"))
            {
                newValue = string.Empty;
            }

            newValue += value;

            if (double.TryParse(newValue, out var result))
            {
                CurrentValue = newValue;
            }
        }

        public void DecimalTapHandler()
        {
            if (CurrentValue.Length == 10 || CurrentValue.Contains("."))
            {
                return;
            }

            CurrentValue += ".";
        }
    }
}
