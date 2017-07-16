using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;
        public CustomerProvider() : this(CultureInfo.CurrentCulture) { }
        public CustomerProvider(IFormatProvider fp)
        {
            parent = fp;
        }
        public object GetFormat(Type t)
        {
            if (t == typeof(ICustomFormatter)) return this;
            return null;
        }
        public string Format(string format, object arg, IFormatProvider prov)
        {
            if (object.ReferenceEquals(arg, null) || arg.GetType() != typeof(Customer)
                || string.IsNullOrEmpty(format) || !(format.ToUpper() == "FULLINFO" || format.ToUpper() == "PN"))
                return string.Format(parent, "{0:" + format + "}", arg);

            Customer customer = (Customer)arg;
            switch (format.ToUpper())
            {
                case "FULLINFO": return $"Name: {customer.Name}   Revenue: {customer.Revenue.ToString("C", parent)}   Phone: {customer.Phone}";
                case "PN":
                    int index = customer.Phone.LastIndexOf(")")+1;
                    while (customer.Phone[index] == ' ') index++;
                    return  customer.Phone.Substring(index);
                default: throw new FormatException($"{nameof(format)} ''{format}'' is not Supported format");
            }
        }
    }
}
