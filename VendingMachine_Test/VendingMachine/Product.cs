using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class Product
    {
        public readonly string name;
        public readonly double cost;

        private const string sChips = "chips";
        private const string sCola = "cola";
        private const string sCandy = "candy";

        private readonly Dictionary<string, double> productValues = new Dictionary<string, double> { { sCandy, .65 }, { sChips, .5 }, { sCola, 1.0 } };

        public static Product chips = new Product(sChips);
        public static Product cola = new Product(sCola);
        public static Product candy = new Product(sCandy);

        private readonly static Dictionary<string, Product> products = new Dictionary<string, Product> { { sCandy, candy }, { sChips, chips }, { sCola, cola } };

        private Product(string productName)
        {
            this.name = productName;
            this.cost = productValues[productName];
        }

        public static Product getProduct(Button button)
        {
            return products[button.ToString()];
        }

        public override string ToString()
        {
            return name;
        }
    }
}
