using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PathExercise
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {

        }

        public Product (string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string getTotalPrice(int n)
        {
            double total = Price * n;

            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" -> R$");
            sb.Append(Price.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append(" x ");
            sb.Append(n);
            sb.Append(" = R$");
            sb.Append(total.ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
