using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public sealed class Button
    {
        private readonly string name;
        private readonly int value;

        public static readonly Button Chips = new Button("chips", 0);
        public static readonly Button Candy = new Button("candy", 1);
        public static readonly Button Cola = new Button("cola", 2);

        private Button(string name, int val)
        {
            this.name = name;
            this.value = val;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
