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

        private void NumberButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.NumberTapHandler(((CalcButton)sender).Text));
        }

        private void SignButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.SignTapHandler());
        }
        private void DecimalButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.DecimalTapHandler());
        }

        private void AddButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.AddTapHandler());
        }

        private void SubtractButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.SubtractTapHandler());
        }

        private void MultiplyButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.MultiplyTapHandler());
        }

        private void DivideButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.DivideTapHandler());
        }

        private void EqualsButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.EqualsTapHandler());
        }
    }
}
