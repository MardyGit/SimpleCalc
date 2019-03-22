using SimpleCalc.Controls;
using SimpleCalc.VMs;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = Vm;
        }

        public MainPageVm Vm { get; } = new MainPageVm();

        private async void CancelButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.CancelTapHandler());
        }

        private async void NumberButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.NumberTapHandler(((CalcButton)sender).Text));
        }

        private async void SignButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.SignTapHandler());
        }

        private async void DecimalButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.DecimalTapHandler());
        }

        private async void AddButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.AddTapHandler());
        }

        private async void SubtractButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.SubtractTapHandler());
        }

        private async void MultiplyButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.MultiplyTapHandler());
        }

        private async void DivideButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.DivideTapHandler());
        }

        private async void EqualsButton_OnTapped(object sender, EventArgs e)
        {
            await Task.Run(() => Vm.EqualsTapHandler());
        }
    }
}
