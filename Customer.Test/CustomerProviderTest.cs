using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Customer;

namespace Customer.Test
{
    [TestFixture]
    class CustomerProviderTest
    {
        [TestCase("FULLINFO", ExpectedResult = "Name: Jeffrey Richter   Revenue: 1 000 000,00 ₽   Phone: +1 (425) 555-0100")]
        [TestCase("PN", ExpectedResult = "555-0100")]
        [TestCase("R", ExpectedResult = "1 000 000,00 ₽")]
        [TestCase("nR", ExpectedResult = "Jeffrey Richter   1 000 000,00 ₽")]
        public string Format_NormalFormat_PositiveTest(string format)
        {
            IFormatProvider cp = new CustomerProvider();
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return string.Format(cp, "{0:" + format + "}", customer);
        }

        [TestCase("LOR")]
        [TestCase("B")]
        public void Format_InvalidFormat_ThrowsFormatException(string format)
        {
            IFormatProvider cp = new CustomerProvider();
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            Assert.Throws<FormatException>(()=> string.Format(cp, "{0:" + format + "}", customer));
        }

    }
}
