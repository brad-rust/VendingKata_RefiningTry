using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class Products
    {
        public Product Candy;
        public Product Chips;
        public Product Cola;

        private readonly Dictionary<string, dynamic> products;

        public Products()
        {
            this.Candy = new _Candy();
            this.Chips = new _Chips();
            this.Cola = new _Cola();
            products = new Dictionary<string, dynamic> { { Product.Candy, this.Candy }, { Product.Chips, this.Chips }, { Product.Cola, this.Cola } };
        }

        public Product getProduct(string buttonName)
        {
            return products[buttonName];
        }
        
    }

    public class Product
    {
        public const string Candy = "candy";
        public const string Cola = "cola";
        public const string Chips = "chips";

        public string name { protected set; get; }
        public double cost { protected set; get; }
        public int quantityOnHand { private set; get; }

        public void putProductInInventory(int qty)
        {
            this.quantityOnHand += qty;
        }

        public bool subtractVendedProduct()
        {
            if (this.quantityOnHand <= 0)
                return false;
            --this.quantityOnHand;
            return true;            
        }
    }

    public class _Chips : Product
    {
        private const string _name = "chips";
        private const double _cost = .5;
        public _Chips()
        {
            name = _name;
            cost = _cost;
        }
    }

    public class _Candy : Product
    {
        private const string _name = "candy";
        private const double _cost = .65;
        public _Candy()
        {
            name = _name;
            cost = _cost;
        }
    }

    public class _Cola : Product
    {
        private const string _name = "cola";
        private const double _cost = 1.0;
        public _Cola()
        {
            name = _name;
            cost = _cost;
        }
    }
}
