using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VendingMachine_Kata;

namespace VendingMachine_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void whenNoCoinsHaveBeenInserted_displayReadsInsertCoin()
        {
            VendingMachine vm = new VendingMachine();
            Assert.AreEqual(vm.display.message, "INSERT COIN");
        }
    }
}
