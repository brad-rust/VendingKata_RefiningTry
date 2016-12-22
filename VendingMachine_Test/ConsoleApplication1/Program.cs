using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VendingMachine_Kata;

namespace ConsoleApplication1
{
    class Program
    {
        private const string sQuarter = "quarter";
        private const string sDime = "dime";
        private const string sNickel = "nickel";

        static void Main(string[] args)
        {
            VendingMachine vm = place2QuartersInMachine();
            stockCandyAndChips(vm);
            vm.pressButton(vm.Button.Chips);
            List<string> contents = new List<string>();
            string item = vm.dispenser.removeContents();
        }

        private static VendingMachine place2QuartersInMachine()
        {
            VendingMachine vm = new VendingMachine();
            vm.insertCoin(sQuarter);
            vm.insertCoin(sQuarter);
            return vm;
        }

        private static void stockCandyAndChips(VendingMachine vm)
        {
            vm.stockProduct(Product.Chips, 1);
            vm.stockProduct(Product.Candy, 1);
        }
    }
}
