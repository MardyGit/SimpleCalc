using NUnit.Framework;
using SimpleCalc.VMs;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void CheckAdd()
        {
            var vm = new MainPageVm();
            vm.NumberTapHandler("2");
            vm.NumberTapHandler("8");
            vm.DecimalTapHandler();
            vm.NumberTapHandler("4");
            vm.AddTapHandler();
            vm.NumberTapHandler("1");
            vm.NumberTapHandler("3");
            vm.DecimalTapHandler();
            vm.NumberTapHandler("6");
            vm.EqualsTapHandler();
            Assert.AreEqual("42", vm.StringValue);
        }

        [Test]
        public void CheckSubtract()
        {
            var vm = new MainPageVm();
            vm.NumberTapHandler("8");
            vm.NumberTapHandler("2");
            vm.SubtractTapHandler();
            vm.NumberTapHandler("4");
            vm.NumberTapHandler("0");
            vm.EqualsTapHandler();
            Assert.AreEqual("42", vm.StringValue);
        }

        [Test]
        public void CheckMultiply()
        {
            var vm = new MainPageVm();
            vm.NumberTapHandler("6");
            vm.MultiplyTapHandler();
            vm.NumberTapHandler("7");
            vm.EqualsTapHandler();
            Assert.AreEqual("42", vm.StringValue);
        }

        [Test]
        public void CheckInput()
        {
            var vm = new MainPageVm();
            vm.NumberTapHandler("1");
            vm.NumberTapHandler("2");
            vm.NumberTapHandler("3");
            vm.DecimalTapHandler();
            vm.NumberTapHandler("4");
            vm.NumberTapHandler("5");
            Assert.AreEqual("123.45", vm.StringValue);
        }

        [Test]
        public void CheckDivide()
        {
            var vm = new MainPageVm();
            vm.NumberTapHandler("1");
            vm.NumberTapHandler("4");
            vm.NumberTapHandler("7");
            vm.NumberTapHandler("5");
            vm.NumberTapHandler("1");
            vm.DecimalTapHandler();
            vm.NumberTapHandler("6");
            vm.NumberTapHandler("6");
            vm.DivideTapHandler();
            vm.NumberTapHandler("3");
            vm.NumberTapHandler("5");
            vm.NumberTapHandler("1");
            vm.DecimalTapHandler();
            vm.NumberTapHandler("2");
            vm.NumberTapHandler("3");
            vm.EqualsTapHandler();
            Assert.AreEqual("42", vm.StringValue);
        }

        [Test]
        public void ChangeSign()
        {
            var vm = new MainPageVm();
            vm.NumberTapHandler("1");
            vm.NumberTapHandler("2");
            vm.NumberTapHandler("3");
            vm.SignTapHandler();
            Assert.AreEqual("-123", vm.StringValue);
        }

        [Test]
        public void DivideByZero()
        {
            var vm = new MainPageVm();
            vm.NumberTapHandler("7");
            vm.DivideTapHandler();
            vm.NumberTapHandler("0");
            vm.EqualsTapHandler();
            Assert.AreEqual(MainPageVm.ErrorState, vm.StringValue);
        }
    }
}