using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class CoinReturn
    {
        private List<string> coins;

        public CoinReturn()
        {
            this.coins = new List<string>();
        }

        public List<string> slot()
        {
            return coins;
        }

        public void placeCoinInSlot(Coin coin)
        {
            this.coins.Add(coin.name);
        }

    }
}
