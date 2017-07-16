using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class Customer : IEquatable<Customer>, IFormattable
    {
        public string Name { get; }
        public string Phone { get; }
        public decimal Revenue { get; }

        public Customer(string name, string phone, decimal revenue)
        {
            if(string.IsNullOrEmpty(name)||string.IsNullOrEmpty(phone)) throw new ArgumentException();
            if(revenue<0) throw new ArgumentOutOfRangeException($"Negative {nameof(revenue)}");
            Name = name;
            Phone = phone;
            Revenue = revenue;
        }
        public bool Equals(Customer other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (this.Name != other.Name || this.Phone != other.Phone || this.Revenue != other.Revenue) return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return Equals((Customer)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Name.GetHashCode() + 7 * Phone.GetHashCode() + 11 * Revenue.GetHashCode();
            }
        }

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider prov)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            switch (format.ToUpper())
            {
                case "G": return Name + "  " + Phone + "  " + Revenue.ToString("C", prov);
                case "N": return Name;
                case "FN": return Name.Substring(0, Name.IndexOf(" "));
                case "LN": return Name.Substring(Name.IndexOf(" ") + 1);
                case "P": return Phone;
                case "R": return Revenue.ToString("C", prov);
                case "NR": return Name + "   " + Revenue.ToString("C", prov);

                default: throw new FormatException($"{nameof(format)} ''{format}'' is not Supported format");
            }
        }
    }
}
