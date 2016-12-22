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
        public Button button;

        public Button chipsButton = Button.Chips;
        public Button colaButton = Button.Cola;
        public Button candyButton = Button.Candy;

        public Product chips = Product.chips;
        public Product candy = Product.candy;
        public Product cola = Product.cola;

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

        public void pressButton(Button button)
        {
            Product product = Product.getProduct(button);
            if (this.credit >= product.value)
                this.dispenser.addContentsToDispenser(button.ToString());
        }
    }
}
