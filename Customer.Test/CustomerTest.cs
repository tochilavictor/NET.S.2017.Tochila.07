using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Customer;
namespace Customer.Test
{
    [TestFixture]
    public class CustomerTest
    {
        [TestCase("G",ExpectedResult = "Jeffrey Richter  +1 (425) 555-0100  1 000 000,00 ₽")]
        [TestCase(null, ExpectedResult = "Jeffrey Richter  +1 (425) 555-0100  1 000 000,00 ₽")]
        [TestCase("", ExpectedResult = "Jeffrey Richter  +1 (425) 555-0100  1 000 000,00 ₽")]
        [TestCase("n", ExpectedResult = "Jeffrey Richter")]
        [TestCase("FN", ExpectedResult = "Jeffrey")]
        [TestCase("Ln", ExpectedResult = "Richter")]
        [TestCase("P", ExpectedResult = "+1 (425) 555-0100")]
        [TestCase("R", ExpectedResult = "1 000 000,00 ₽")]
        [TestCase("nR", ExpectedResult = "Jeffrey Richter   1 000 000,00 ₽")]
        public string ToString_NormalFormat_PositiveTest(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return customer.ToString(format);
        }
        [TestCase("C")]
        [TestCase("l")]
        [TestCase("RR")]
        public void ToString_InvalidFormat_ThrowsFormatException(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            Assert.Throws<FormatException>(()=>customer.ToString(format));
        }
    }
}
