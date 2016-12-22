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

        public Products products;
        private List<Coin> insertedCoins;


        public VendingMachine()
        {
            this.display = new Display();
            this._coinReturn = new CoinReturn();
            this.dispenser = new Dispenser();
            this.insertedCoins = new List<Coin>();
            this.Button = new Button();
            this.products = new Products();
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
                pressProductButton(button);
        }
        
        private void pressProductButton(Button button)
        {
            Product product = products.getProduct(button.ToString());
            if (product.subtractVendedProduct())
            {
                if (this.credit >= product.cost)
                    vend(product, button);
            }
            else
                this.display.changeMessageToSoldOut();
                    
        }

        private void vend(Product product, Button button)
        {
            this.dispenser.addContentsToDispenser(button.ToString());
            this.credit -= product.cost;
            makeChange();
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
            while (this.credit > .04)
            {
                Coin coin = Coin.getLargestCoinPossibleToMakeChange(this.credit);
                this._coinReturn.placeCoinInSlot(coin);
                this.credit -= coin.value;
            }            
        }

        public void stockProduct(string productName, int qty)
        {
            Product product = this.products.getProduct(productName);
            product.putProductInInventory(qty);
        }
    }
}
