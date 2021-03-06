﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class Display
    {
        public string message { private set; get; }

        private const string insertCoin = "INSERT COIN";
        private const string soldOut = "SOLD OUT";

        public Display()
        {
            this.message = insertCoin;
        }

        public void changeMessageToCoinsInserted(double coinsInserted)
        {
            this.message = coinsInserted.ToString("0.00");
        }

        public void changeMessageToSoldOut()
        {
            this.message = soldOut;
        }
    }
}
