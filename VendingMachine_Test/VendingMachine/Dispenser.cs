using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Kata
{
    public class Dispenser
    {
        private List<string> dispenserList;

        public Dispenser()
        {
            this.dispenserList = new List<string>();
        }

        public List<string> contents()
        {
            return this.dispenserList;
        }

        public void addContentsToDispenser(string item)
        {
            this.dispenserList.Add(item);
        }
    }
}
