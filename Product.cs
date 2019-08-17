using System.Globalization;
using System.Text;

namespace PathExercise
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {

        }

        public double getTotalPrice()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            double total = Price * Quantity;

            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" -> R$");
            sb.Append(Price.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append(" x ");
            sb.Append(Quantity);
            sb.Append(" = R$");
            sb.Append(getTotalPrice().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
