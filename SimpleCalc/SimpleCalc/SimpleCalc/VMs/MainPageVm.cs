using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SimpleCalc.VMs
{
    public class MainPageVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private enum Operations { None, Add, Subtract, Multiply, Divide }

        private const int MaxLength = 10;

        private string _stringValue = "0";
        private double _resultValue = 0;
        private Operations _operation;
        private bool _resetInput;

        public const string ErrorState = "Error";

        public double Value
        {
            get
            {
                double.TryParse(StringValue, out var result);
                return result;
            }
        }

        private bool IsInputValid => double.TryParse(StringValue, out var result);

        public string StringValue
        {
            get => _stringValue;
            set => HasPropertyChanged(value, ref _stringValue);
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
            if (PropertyChanged != null)
            {
                Device.BeginInvokeOnMainThread(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
            }
        }

        public void NumberTapHandler(string value)
        {
            BeforeInput();

            if (StringValue.Length == MaxLength)
            {
                return;
            }

            var newValue = StringValue;

            if (StringValue == ErrorState  || StringValue == "0" || (StringValue == "0" && value == "0"))
            {
                newValue = string.Empty;
            }

            newValue += value;

            if (double.TryParse(newValue, out var result))
            {
                StringValue = newValue;
            }
        }

        public void CancelTapHandler()
        {
            Reset();
        }

        public void DecimalTapHandler()
        {
            BeforeInput();

            if (StringValue.Length == MaxLength || StringValue.Contains("."))
            {
                return;
            }

            StringValue += ".";
        }

        public void SignTapHandler()
        {
            if (StringValue == ErrorState || StringValue == "0" || !IsInputValid)
            {
                return;
            }

            if (StringValue.StartsWith("-"))
            {
                StringValue = StringValue.Substring(1);
                return;
            }

            if (StringValue.Length == MaxLength)
            {
                return;
            }

            StringValue = "-" + StringValue;
        }

        public void AddTapHandler()
        {
            ApplyPendingOperation(Operations.Add);
        }

        public void SubtractTapHandler()
        {
            ApplyPendingOperation(Operations.Subtract);
        }

        public void DivideTapHandler()
        {
            ApplyPendingOperation(Operations.Divide);
        }

        public void MultiplyTapHandler()
        {
            ApplyPendingOperation(Operations.Multiply);
        }

        public void EqualsTapHandler()
        {
            ApplyPendingOperation(Operations.None);
        }

        private void BeforeInput()
        {
            if (_resetInput)
            {
                StringValue = "0";
                _resetInput = false;
            }
        }

        private void ApplyPendingOperation(Operations nextOperation)
        {
            try
            {
                switch (_operation)
                {
                    case Operations.Add:
                        StringValue = (_resultValue + Value).ToString();
                        break;
                    case Operations.Subtract:
                        StringValue = (_resultValue - Value).ToString();
                        break;
                    case Operations.Multiply:
                        StringValue = (_resultValue * Value).ToString();
                        break;
                    case Operations.Divide:
                        if (Value == 0)
                        {
                            SetError();
                            break;
                        }
                        StringValue = (_resultValue / Value).ToString();
                        break;
                }

                _resultValue = Value;
                _resetInput = true;
            }
            catch
            {
                SetError();
            }

            _operation = nextOperation;
        }

        private void SetError()
        {
            Reset();

            StringValue = ErrorState;
        }

        private void Reset()
        {
            _resultValue = 0;
            StringValue = "0";
            _operation = Operations.None;
        }
    }
}
