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
        private CoinReturn _coinReturn;
        public Dispenser dispenser;

        public readonly Button Button;

        public Product chips = Product.chips;
        public Product candy = Product.candy;
        public Product cola = Product.cola;

        private List<Coin> insertedCoins;


        public VendingMachine()
        {
            this.display = new Display();
            this._coinReturn = new CoinReturn();
            this.dispenser = new Dispenser();
            this.insertedCoins = new List<Coin>();
            this.Button = new Button();
        }

        public void insertCoin(string _coin)
        {
            Coin coin = new Coin(_coin);
            if (coin.value > 0)
            {
                this.credit += coin.value;
                this.display.changeMessageToCoinsInserted(this.credit);
                this.insertedCoins.Add(coin);
            }
            else
                this._coinReturn.placeCoinInSlot(coin);
        }

        public void pressButton(Button button)
        {
            if (button == Button.ReturnCoins)
                returnCoins();
            else
                tryVend(button);
        }
        
        private void tryVend(Button button)
        {
            Product product = Product.getProduct(button);
            if (this.credit >= product.cost)
            {
                this.dispenser.addContentsToDispenser(button.ToString());
                this.credit -= product.cost;
                makeChange();
            }
        }

        private void returnCoins()
        {
            this.credit = 0;
            foreach (Coin coin in insertedCoins)
                this._coinReturn.placeCoinInSlot(coin);
        }

        public List<string> coinReturnSlot()
        {
            return this._coinReturn.slot();
        }

        private void makeChange()
        {
            if (this.credit > .04)
                this._coinReturn.placeCoinInSlot(Coin.Dime);
        }
    }
}
