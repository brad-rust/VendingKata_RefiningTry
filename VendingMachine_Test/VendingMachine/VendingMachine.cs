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

        public VendingMachine()
        {
            this.display = new Display();
        }

        public void insertCoin(string coin)
        {
            this.credit = .25;
            this.display.changeMessageToCoinsInserted(this.credit);
        }
    }
}
