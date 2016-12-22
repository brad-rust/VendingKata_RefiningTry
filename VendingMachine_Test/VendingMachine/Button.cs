using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class Button
    {
        private readonly string _name;
        private readonly int _value;

        public readonly Button Chips;
        public readonly Button Candy;
        public readonly Button Cola;
        public readonly Button ReturnCoins;

        public Button()
        {
            Chips = new Button("chips", 0);
            Candy = new Button("candy", 1);
            Cola = new Button("cola", 2);
            ReturnCoins = new Button("return", 3);
        }
    
        private Button(string name, int val)
        {
            this._name = name;
            this._value = val;
        }

        public override string ToString()
        {
            return _name;
        }

        public int value()
        {
            return this._value;
        }

    }
}
