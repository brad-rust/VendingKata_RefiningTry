using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class Coin
    {
        private const string quarter = "quarter", dime = "dime", nickel = "nickel";
        private const double qval = .25, dVal = .1, nVal = .05;
        private readonly Dictionary<string, double> validCoins = new Dictionary<string, double> { { quarter, qval }, { dime, dVal }, { nickel, nVal } };
        public double value { private set; get; }
        public string name { private set; get; }
                        
        public Coin(string _name)
        {
            this.name = _name;
            double tempVal = 0;
            validCoins.TryGetValue(this.name, out tempVal);
            this.value = tempVal;
        }

        public readonly static Coin Quarter = new Coin(quarter);
        public readonly static Coin Dime = new Coin(dime);
        public readonly static Coin Nickel = new Coin(nickel);
    }
}
