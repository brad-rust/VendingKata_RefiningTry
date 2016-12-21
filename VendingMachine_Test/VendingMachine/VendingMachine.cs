using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class VendingMachine
    {
        public Display display;
        public double credit { private set; get; }
        public CoinReturn coinReturn;
        public Dispenser dispenser;
        public VendingMachine()
        {
            this.display = new Display();
            this.coinReturn = new CoinReturn();
            this.dispenser = new Dispenser();

        }

        public void insertCoin(string _coin)
        {
            Coin coin = new Coin(_coin);
            if (coin.value > 0)
            {
                this.credit += coin.value;
                this.display.changeMessageToCoinsInserted(this.credit);
            }
            else
                this.coinReturn.placeCoinInSlot(coin);
        }

        public void pressButton(string item)
        {
            this.dispenser.addContentsToDispenser(item);
        }
    }
}
