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
    
        private void DecimalButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.DecimalTapHandler());
        }

        private void SignButton_OnTapped(object sender, EventArgs e)
        {
            Task.Run(() => Vm.SignTapHandler());
        }
    }
}
